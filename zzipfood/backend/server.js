const express = require("express");
const sqlite3 = require("sqlite3").verbose();
const cors = require("cors");
const bodyParser = require("body-parser");

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
