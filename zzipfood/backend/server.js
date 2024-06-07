const express = require("express");
const sqlite3 = require("sqlite3").verbose();
const cors = require("cors");
const bodyParser = require("body-parser");
const axios = require("axios");

const app = express();
const port = 5000;

// Middleware
app.use(cors());
app.use(bodyParser.json());

// SQLite 데이터베이스 연결
const db = new sqlite3.Database(":memory:");

// 데이터베이스 초기화
db.serialize(() => {
  db.run(`CREATE TABLE foods (
    name TEXT,
    restaurantPrice INTEGER,
    ingredientCost INTEGER,
    recipe TEXT
  )`);

  db.run(`CREATE TABLE ingredients (
    name TEXT,
    expiryDate TEXT
  )`);

  const stmt = db.prepare("INSERT INTO foods VALUES (?, ?, ?, ?)");
  stmt.run(
    "김치찌개",
    8000,
    5000,
    "1. 김치 준비\n2. 돼지고기와 함께 끓이기\n3. 완성!"
  );
  stmt.run(
    "된장찌개",
    7000,
    4000,
    "1. 된장 준비\n2. 야채와 함께 끓이기\n3. 완성!"
  );
  stmt.finalize();
});

// 한국농수산식품유통공사 API 키
const AT_API_KEY = "YOUR_AT_API_KEY"; // 공공데이터 포털에서 발급받은 키를 입력

// 서울특별시농수산식품공사 API 키
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

// 식재료 가격 API
app.get("/api/ingredient-price/:name", async (req, res) => {
  try {
    const name = req.params.name;

    // 한국농수산식품유통공사 API 호출
    const atResponse = await axios.get(
      `https://www.kamis.or.kr/service/price/xml.do?action=dailySalesList&p_cert_key=${AT_API_KEY}&p_cert_id=your_cert_id&p_returntype=json&p_product_cls_code=01&p_start_day=2022-01-01&p_end_day=2022-12-31`
    );
    const atPrice = atResponse.data.price;

    // 서울특별시농수산식품공사 API 호출
    const seoulResponse = await axios.get(
      `http://openapi.seoul.go.kr:8088/${SEOUL_API_KEY}/json/ListNecessariesPricesService/1/5/${encodeURIComponent(
        name
      )}`
    );
    const seoulPrice =
      seoulResponse.data.ListNecessariesPricesService.row[0].M_PRICE;

    const price = (atPrice + seoulPrice) / 2; // 두 가격의 평균을 사용

    res.send({ name, price });
  } catch (error) {
    console.error("Error fetching ingredient price:", error);
    res.status(500).send("Error fetching ingredient price");
  }
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
