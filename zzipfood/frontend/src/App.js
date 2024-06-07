import React, { useState, useEffect } from "react";
import axios from "axios";
import "./App.css";

function App() {
  const [ingredients, setIngredients] = useState([]);

  useEffect(() => {
    axios
      .get("/api/ingredients")
      .then((response) => {
        setIngredients(response.data);
      })
      .catch((error) => {
        console.error("Error fetching ingredients:", error);
      });
  }, []);

  return (
    <div className="container">
      <h1>냉장고 재료 확인</h1>
      <h2>재료 리스트 (유통기한 순)</h2>
      <ul>
        {ingredients.map((ingredient) => (
          <li key={ingredient.name}>
            {ingredient.name} - 유통기한:{" "}
            {new Date(ingredient.expiryDate).toLocaleDateString()}
          </li>
        ))}
      </ul>
      <h2>추천 요리</h2>
      <ul>
        <li>고기볶음</li>
        <li>양파수프</li>
        <li>당근라페</li>
      </ul>
    </div>
  );
}

export default App;
