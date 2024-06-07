const express = require("express");
const sqlite3 = require("sqlite3").verbose();
const cors = require("cors");
const bodyParser = require("body-parser");
const axios = require("axios");
const path = require("path");

const app = express();
const port = 5000;

// Middleware
app.use(cors());
app.use(bodyParser.json());

// SQLite 데이터베이스 파일 경로
const dbPath = path.resolve(__dirname, "zzipfood.db");

// SQLite 데이터베이스 연결
const db = new sqlite3.Database(dbPath, (err) => {
  if (err) {
    console.error("Error opening database", err);
  } else {
    // 데이터베이스 초기화
    db.serialize(() => {
      db.run(`CREATE TABLE IF NOT EXISTS foods (
        name TEXT,
        restaurantPrice INTEGER,
        ingredientCost INTEGER,
        recipe TEXT,
        ingredients TEXT
      )`);

      db.run(`CREATE TABLE IF NOT EXISTS ingredients (
        name TEXT,
        expiryDate TEXT
      )`);

      // 초기 데이터 삽입
      db.get("SELECT COUNT(*) AS count FROM foods", (err, row) => {
        if (err) {
          console.error("Error checking foods table", err);
        } else if (row.count === 0) {
          const stmt = db.prepare(
            "INSERT INTO foods (name, restaurantPrice, ingredientCost, recipe, ingredients) VALUES (?, ?, ?, ?, ?)"
          );
          stmt.run(
            "김치찌개",
            8000,
            5000,
            "1. 김치 준비\n2. 돼지고기와 함께 끓이기\n3. 완성!",
            "김치, 돼지고기, 두부, 양파, 대파, 고춧가루"
          );
          stmt.run(
            "된장찌개",
            7000,
            4000,
            "1. 된장 준비\n2. 야채와 함께 끓이기\n3. 완성!",
            "된장, 두부, 감자, 양파, 대파"
          );
          stmt.finalize();
        }
      });
    });
  }
});

// 공공데이터 API 키
const AT_API_KEY = "YOUR_AT_API_KEY"; // 공공데이터 포털에서 발급받은 키를 입력
const SEOUL_API_KEY = "YOUR_SEOUL_API_KEY"; // 공공데이터 포털에서 발급받은 키를 입력

// API 엔드포인트
app.get("/", (req, res) => {
  res.send("Hello, world!");
});

// 음식 검색 API
app.get("/api/foods/:name", (req, res) => {
  const name = req.params.name;
  db.get("SELECT * FROM foods WHERE name = ?", [name], (err, row) => {
    if (err) {
      res.status(500).send("Error fetching food");
    } else if (!row) {
      res.status(404).send("Food not found");
    } else {
      res.send(row);
    }
  });
});

// 개별 재료 가격을 가져오는 함수
async function getIngredientPrice(name) {
  try {
    // 한국농수산식품유통공사 API 호출
    const atResponse = await axios.get(
      `https://www.kamis.or.kr/service/price/xml.do?action=dailySalesList&p_cert_key=${AT_API_KEY}&p_cert_id=your_cert_id&p_returntype=json&p_product_cls_code=01&p_start_day=2022-01-01&p_end_day=2022-12-31&p_item_code=${encodeURIComponent(
        name
      )}`
    );
    const atPrices = atResponse.data.data.item;
    const atPrice =
      atPrices && atPrices.length > 0 ? parseInt(atPrices[0].dpr1, 10) : null;

    // 서울특별시농수산식품공사 API 호출
    const seoulResponse = await axios.get(
      `http://openapi.seoul.go.kr:8088/${SEOUL_API_KEY}/json/ListNecessariesPricesService/1/5/${encodeURIComponent(
        name
      )}`
    );
    const seoulPrices = seoulResponse.data.ListNecessariesPricesService.row;
    const seoulPrice =
      seoulPrices && seoulPrices.length > 0
        ? parseInt(seoulPrices[0].M_PRICE, 10)
        : null;

    if (atPrice && seoulPrice) {
      return (atPrice + seoulPrice) / 2; // 두 가격의 평균을 반환
    } else if (atPrice) {
      return atPrice;
    } else if (seoulPrice) {
      return seoulPrice;
    } else {
      return null;
    }
  } catch (error) {
    console.error("Error fetching ingredient price:", error);
    return null;
  }
}

// 식재료 가격 API
app.get("/api/ingredient-prices/:name", async (req, res) => {
  const name = req.params.name;
  db.get(
    "SELECT ingredients FROM foods WHERE name = ?",
    [name],
    async (err, row) => {
      if (err) {
        res.status(500).send("Error fetching ingredients");
      } else if (!row) {
        res.status(404).send("Food not found");
      } else {
        const ingredients = row.ingredients.split(", ");
        const prices = {};
        for (const ingredient of ingredients) {
          const price = await getIngredientPrice(ingredient);
          prices[ingredient] = price;
        }
        res.send(prices);
      }
    }
  );
});

// 냉장고 재료 API
app.get("/api/ingredients", (req, res) => {
  db.all(
    "SELECT * FROM ingredients ORDER BY expiryDate ASC",
    [],
    (err, rows) => {
      if (err) {
        res.status(500).send("Error fetching ingredients");
      } else {
        res.send(rows);
      }
    }
  );
});

app.post("/api/ingredients", (req, res) => {
  const { name, expiryDate } = req.body;
  db.run(
    "INSERT INTO ingredients (name, expiryDate) VALUES (?, ?)",
    [name, expiryDate],
    function (err) {
      if (err) {
        res.status(500).send("Error adding ingredient");
      } else {
        res.send({ id: this.lastID });
      }
    }
  );
});

// 서버 시작
app.listen(port, () => {
  console.log(`Server running on port ${port}`);
});
