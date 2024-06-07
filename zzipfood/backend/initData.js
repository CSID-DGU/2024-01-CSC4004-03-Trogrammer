const mongoose = require("mongoose");

mongoose.connect("mongodb://localhost:27017/zzipfood", {
  useNewUrlParser: true,
  useUnifiedTopology: true,
});

const Food = mongoose.model(
  "Food",
  new mongoose.Schema({
    name: String,
    restaurantPrice: Number,
    ingredientCost: Number,
    recipe: String,
  })
);

const foods = [
  {
    name: "김치찌개",
    restaurantPrice: 8000,
    ingredientCost: 5000,
    recipe: "1. 김치 준비\n2. 돼지고기와 함께 끓이기\n3. 완성!",
  },
  {
    name: "된장찌개",
    restaurantPrice: 7000,
    ingredientCost: 4000,
    recipe: "1. 된장 준비\n2. 야채와 함께 끓이기\n3. 완성!",
  },
];

foods.forEach(async (food) => {
  const newFood = new Food(food);
  await newFood.save();
});

mongoose.disconnect();
