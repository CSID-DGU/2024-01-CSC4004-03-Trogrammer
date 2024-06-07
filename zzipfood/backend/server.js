const express = require("express");
const sqlite3 = require("sqlite3").verbose();
const cors = require("cors");
const bodyParser = require("body-parser");
const path = require("path");

const app = express();
const port = 5000;

// Middleware 설정
app.use(cors());
app.use(bodyParser.json());

// SQLite 데이터베이스 파일 경로 설정
const dbPath = path.resolve(__dirname, "zzipfood.db");

// SQLite 데이터베이스 연결
const db = new sqlite3.Database(dbPath, (err) => {
  if (err) {
    console.error("Database connection error:", err.message);
  } else {
    console.log("Connected to the SQLite database");
    // 데이터베이스 초기화 및 데이터 삽입
    db.serialize(() => {
      db.run("DROP TABLE IF EXISTS foods");
      db.run("DROP TABLE IF EXISTS ingredients");

      db.run(`CREATE TABLE IF NOT EXISTS foods (
        name TEXT,
        restaurantName TEXT,
        restaurantPrice INTEGER,
        ingredientCost INTEGER,
        recipe TEXT,
        ingredients TEXT
      )`);

      db.run(`CREATE TABLE IF NOT EXISTS ingredients (
        name TEXT,
        price INTEGER,
        expiryDate TEXT
      )`);

      // 초기 데이터 삽입
      db.get("SELECT COUNT(*) AS count FROM foods", (err, row) => {
        if (err) {
          console.error("Error checking foods table:", err);
        } else if (row.count === 0) {
          const stmt = db.prepare(
            "INSERT INTO foods (name, restaurantName, restaurantPrice, ingredientCost, recipe, ingredients) VALUES (?, ?, ?, ?, ?, ?)"
          );
          stmt.run(
            "김치찌개",
            "한식당",
            8000,
            5000,
            "1. 김치 준비\n2. 돼지고기와 함께 끓이기\n3. 완성!",
            "김치, 돼지고기, 두부, 양파, 대파, 고춧가루"
          );
          stmt.run(
            "김치찌개",
            "맛있는 집",
            8500,
            5000,
            "1. 김치 준비\n2. 돼지고기와 함께 끓이기\n3. 완성!",
            "김치, 돼지고기, 두부, 양파, 대파, 고춧가루"
          );
          stmt.run(
            "김치찌개",
            "정겨운 식당",
            9000,
            5000,
            "1. 김치 준비\n2. 돼지고기와 함께 끓이기\n3. 완성!",
            "김치, 돼지고기, 두부, 양파, 대파, 고춧가루"
          );

          stmt.run(
            "된장찌개",
            "한식당",
            7000,
            4000,
            "1. 된장 준비\n2. 야채와 함께 끓이기\n3. 완성!",
            "된장, 두부, 애호박, 고추"
          );
          stmt.run(
            "된장찌개",
            "맛있는 집",
            7500,
            4000,
            "1. 된장 준비\n2. 야채와 함께 끓이기\n3. 완성!",
            "된장, 두부, 애호박, 고추"
          );
          stmt.run(
            "된장찌개",
            "정겨운 식당",
            8000,
            4000,
            "1. 된장 준비\n2. 야채와 함께 끓이기\n3. 완성!",
            "된장, 두부, 애호박, 고추"
          );

          stmt.run(
            "비빔밥",
            "한식당",
            9000,
            6000,
            "1. 밥 준비\n2. 야채와 고기와 함께 비비기\n3. 고추장 넣기\n4. 완성!",
            "밥, 고추장, 소고기, 시금치, 당근, 콩나물, 계란"
          );
          stmt.run(
            "비빔밥",
            "맛있는 집",
            9500,
            6000,
            "1. 밥 준비\n2. 야채와 고기와 함께 비비기\n3. 고추장 넣기\n4. 완성!",
            "밥, 고추장, 소고기, 시금치, 당근, 콩나물, 계란"
          );
          stmt.run(
            "비빔밥",
            "정겨운 식당",
            10000,
            6000,
            "1. 밥 준비\n2. 야채와 고기와 함께 비비기\n3. 고추장 넣기\n4. 완성!",
            "밥, 고추장, 소고기, 시금치, 당근, 콩나물, 계란"
          );

          stmt.run(
            "불고기",
            "고기집",
            12000,
            7000,
            "1. 소고기 양념하기\n2. 야채와 함께 볶기\n3. 완성!",
            "소고기, 양파, 당근, 대파, 마늘, 간장, 설탕"
          );
          stmt.run(
            "불고기",
            "맛있는 집",
            12500,
            7000,
            "1. 소고기 양념하기\n2. 야채와 함께 볶기\n3. 완성!",
            "소고기, 양파, 당근, 대파, 마늘, 간장, 설탕"
          );
          stmt.run(
            "불고기",
            "정겨운 식당",
            13000,
            7000,
            "1. 소고기 양념하기\n2. 야채와 함께 볶기\n3. 완성!",
            "소고기, 양파, 당근, 대파, 마늘, 간장, 설탕"
          );

          stmt.run(
            "김밥",
            "분식집",
            5000,
            3000,
            "1. 김밥 재료 준비\n2. 밥과 재료를 김에 말기\n3. 완성!",
            "김, 밥, 단무지, 시금치, 당근, 햄, 계란"
          );
          stmt.run(
            "김밥",
            "맛있는 집",
            5500,
            3000,
            "1. 김밥 재료 준비\n2. 밥과 재료를 김에 말기\n3. 완성!",
            "김, 밥, 단무지, 시금치, 당근, 햄, 계란"
          );
          stmt.run(
            "김밥",
            "정겨운 식당",
            6000,
            3000,
            "1. 김밥 재료 준비\n2. 밥과 재료를 김에 말기\n3. 완성!",
            "김, 밥, 단무지, 시금치, 당근, 햄, 계란"
          );

          stmt.run(
            "잡채",
            "한식당",
            10000,
            6000,
            "1. 당면 삶기\n2. 고기와 야채 볶기\n3. 당면과 함께 볶기\n4. 완성!",
            "당면, 소고기, 시금치, 당근, 양파, 대파, 간장, 설탕"
          );
          stmt.run(
            "잡채",
            "맛있는 집",
            10500,
            6000,
            "1. 당면 삶기\n2. 고기와 야채 볶기\n3. 당면과 함께 볶기\n4. 완성!",
            "당면, 소고기, 시금치, 당근, 양파, 대파, 간장, 설탕"
          );
          stmt.run(
            "잡채",
            "정겨운 식당",
            11000,
            6000,
            "1. 당면 삶기\n2. 고기와 야채 볶기\n3. 당면과 함께 볶기\n4. 완성!",
            "당면, 소고기, 시금치, 당근, 양파, 대파, 간장, 설탕"
          );

          stmt.finalize();
        }
      });

      db.get("SELECT COUNT(*) AS count FROM ingredients", (err, row) => {
        if (err) {
          console.error("Error checking ingredients table:", err);
        } else if (row.count === 0) {
          const stmt = db.prepare(
            "INSERT INTO ingredients (name, price, expiryDate) VALUES (?, ?, ?)"
          );
          stmt.run("김치", 2000, "2024-12-01");
          stmt.run("돼지고기", 3000, "2024-12-05");
          stmt.run("두부", 1000, "2024-12-10");
          stmt.run("양파", 500, "2024-12-15");
          stmt.run("대파", 500, "2024-12-20");
          stmt.run("고춧가루", 1000, "2024-12-25");
          stmt.run("된장", 1500, "2024-12-30");
          stmt.run("애호박", 1000, "2025-01-01");
          stmt.run("고추", 500, "2025-01-05");
          stmt.run("밥", 1000, "2025-01-10");
          stmt.run("고추장", 500, "2025-01-15");
          stmt.run("소고기", 4000, "2025-01-20");
          stmt.run("시금치", 1000, "2025-01-25");
          stmt.run("당근", 500, "2025-01-30");
          stmt.run("콩나물", 1000, "2025-02-01");
          stmt.run("계란", 300, "2025-02-05");
          stmt.run("햄", 1000, "2025-02-10");
          stmt.run("마늘", 500, "2025-02-15");
          stmt.run("김", 1000, "2025-02-20");
          stmt.run("단무지", 500, "2025-02-25");
          stmt.run("설탕", 500, "2025-03-01");

          stmt.finalize();
        }
      });
    });
  }
});

// 음식 검색 API
app.get("/api/foods/:name", (req, res) => {
  const name = req.params.name;
  db.all("SELECT * FROM foods WHERE name = ?", [name], (err, rows) => {
    if (err) {
      res.status(500).send("Error fetching food");
    } else if (rows.length === 0) {
      res.status(404).send("Food not found");
    } else {
      res.send(rows);
    }
  });
});

// 재료 가격 API
app.get("/api/ingredient-prices/:name", (req, res) => {
  const name = req.params.name;
  db.get("SELECT ingredients FROM foods WHERE name = ?", [name], (err, row) => {
    if (err) {
      res.status(500).send("Error fetching ingredients");
    } else if (!row) {
      res.status(404).send("Food not found");
    } else {
      const ingredients = row.ingredients.split(", ");
      const prices = {};
      let totalCost = 0;

      db.all(
        "SELECT name, price FROM ingredients WHERE name IN (" +
          ingredients.map(() => "?").join(",") +
          ")",
        ingredients,
        (err, rows) => {
          if (err) {
            res.status(500).send("Error fetching ingredient prices");
          } else {
            rows.forEach((ingredient) => {
              prices[ingredient.name] = ingredient.price;
              totalCost += ingredient.price;
            });
            res.send({ prices, totalCost });
          }
        }
      );
    }
  });
});

// 냉장고 재료 리스트 가져오기
app.get("/api/ingredients", (req, res) => {
  const sql = "SELECT * FROM ingredients ORDER BY expiryDate";
  db.all(sql, [], (err, rows) => {
    if (err) {
      res.status(500).json({ error: err.message });
      return;
    }
    res.json(rows);
  });
});

// 서버 시작
app.listen(port, () => {
  console.log(`Server is running on http://localhost:${port}`);
});
