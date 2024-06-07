const express = require("express");
const mongoose = require("mongoose");
const cors = require("cors");
const bodyParser = require("body-parser");
const axios = require("axios");

const app = express();
const port = 5000;

// Middleware
app.use(cors());
app.use(bodyParser.json());

// MongoDB 연결
mongoose.connect("mongodb://localhost:27017/zzipfood", {
  useNewUrlParser: true,
  useUnifiedTopology: true,
});

// 모델 정의
const Food = mongoose.model(
  "Food",
  new mongoose.Schema({
    name: String,
    restaurantPrice: Number,
    ingredientCost: Number,
    recipe: String,
  })
);

const Ingredient = mongoose.model(
  "Ingredient",
  new mongoose.Schema({
    name: String,
    expiryDate: Date,
  })
);

// 서울특별시농수산식품공사 API
const SEOUL_API_URL = "https://api.seoul.go.kr/api/sub-key";
const SEOUL_API_KEY = "YOUR_SEOUL_API_KEY";

// 한국농수산식품유통공사 API
const AT_API_URL = "https://api.at.or.kr/openapi/ats-service-key";
const AT_API_KEY = "YOUR_AT_API_KEY";

// API 엔드포인트
app.get("/", (req, res) => {
  res.send("Hello, world!");
});

// 음식 검색 API
app.get("/api/foods/:name", async (req, res) => {
  try {
    const food = await Food.findOne({ name: req.params.name });
    if (!food) return res.status(404).send("Food not found");
    res.send(food);
  } catch (error) {
    res.status(500).send("Error fetching food");
  }
});

// 식재료 가격 API
app.get("/api/ingredient-price/:name", async (req, res) => {
  try {
    // 서울특별시농수산식품공사 API 호출
    const seoulResponse = await axios.get(
      `${SEOUL_API_URL}?ServiceKey=${SEOUL_API_KEY}&item=${req.params.name}`
    );
    const seoulPrice = seoulResponse.data.price;

    // 한국농수산식품유통공사 API 호출
    const atResponse = await axios.get(
      `${AT_API_URL}?ServiceKey=${AT_API_KEY}&item=${req.params.name}`
    );
    const atPrice = atResponse.data.price;

    const price = (seoulPrice + atPrice) / 2; // 두 가격의 평균을 사용

    res.send({ name: req.params.name, price });
  } catch (error) {
    console.error("Error fetching ingredient price:", error);
    res.status(500).send("Error fetching ingredient price");
  }
});

// 냉장고 재료 API
app.get("/api/ingredients", async (req, res) => {
  const ingredients = await Ingredient.find().sort({ expiryDate: 1 });
  res.send(ingredients);
});

app.post("/api/ingredients", async (req, res) => {
  const ingredient = new Ingredient(req.body);
  await ingredient.save();
  res.send(ingredient);
});

// 서버 시작
app.listen(port, () => {
  console.log(`Server running on port ${port}`);
});
