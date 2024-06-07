import React, { useState } from "react";
import axios from "axios";
import "../App.css";

function FoodSearchPage() {
  const [food, setFood] = useState("");
  const [result, setResult] = useState(null);
  const [ingredientPrices, setIngredientPrices] = useState({});

  const handleSearch = async () => {
    try {
      const foodResponse = await axios.get(
        `http://localhost:5000/api/foods/${food}`
      );
      setResult(foodResponse.data);

      const pricesResponse = await axios.get(
        `http://localhost:5000/api/ingredient-prices/${food}`
      );
      setIngredientPrices(pricesResponse.data);
    } catch (error) {
      console.error("Error fetching the food data:", error);
    }
  };

  return (
    <div className="container">
      <h1>먹고싶은 음식 검색</h1>
      <input
        type="text"
        value={food}
        onChange={(e) => setFood(e.target.value)}
        placeholder="음식을 입력하세요"
      />
      <button onClick={handleSearch}>검색</button>

      {result && (
        <div>
          <h2>검색 결과</h2>
          <p>식당 가격: {result.restaurantPrice}원</p>
          <p>재료 비용: {result.ingredientCost}원</p>
          <h3>레시피</h3>
          <pre>{result.recipe}</pre>
          <h3>재료 가격</h3>
          <ul>
            {Object.entries(ingredientPrices).map(([ingredient, price]) => (
              <li key={ingredient}>
                {ingredient}: {price ? `${price}원` : "가격 정보 없음"}
              </li>
            ))}
          </ul>
        </div>
      )}
    </div>
  );
}

export default FoodSearchPage;
