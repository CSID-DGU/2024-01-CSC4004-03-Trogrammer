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
        price INTEGER
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
            "된장, 두부, 애호박, 고추"
          );
          stmt.finalize();
        }
      });

      db.get("SELECT COUNT(*) AS count FROM ingredients", (err, row) => {
        if (err) {
          console.error("Error checking ingredients table", err);
        } else if (row.count === 0) {
          const stmt = db.prepare(
            "INSERT INTO ingredients (name, price) VALUES (?, ?)"
          );
          stmt.run("김치", 2000);
          stmt.run("돼지고기", 3000);
          stmt.run("두부", 1000);
          stmt.run("양파", 500);
          stmt.run("대파", 500);
          stmt.run("고춧가루", 1000);
          stmt.run("된장", 1500);
          stmt.run("애호박", 1000);
          stmt.run("고추", 500);
          stmt.finalize();
        }
      });
    });
  }
});

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

// 냉장고 재료 API
app.get("/api/ingredients", (req, res) => {
  db.all("SELECT * FROM ingredients ORDER BY name ASC", [], (err, rows) => {
    if (err) {
      res.status(500).send("Error fetching ingredients");
    } else {
      res.send(rows);
    }
  });
});

app.post("/api/ingredients", (req, res) => {
  const { name, price } = req.body;
  db.run(
    "INSERT INTO ingredients (name, price) VALUES (?, ?)",
    [name, price],
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
