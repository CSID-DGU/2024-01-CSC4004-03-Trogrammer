import React, { useState, useEffect } from "react";
import axios from "axios";
import "../App.css";

function FridgePage() {
  const [ingredients, setIngredients] = useState([]);

  useEffect(() => {
    const fetchIngredients = async () => {
      try {
        const response = await axios.get(
          "http://localhost:5000/api/ingredients"
        );
        setIngredients(response.data);
      } catch (error) {
        console.error("Error fetching ingredients:", error);
      }
    };

    fetchIngredients();
  }, []);

  const sortedIngredients = [...ingredients].sort(
    (a, b) => new Date(a.expiryDate) - new Date(b.expiryDate)
  );

  const recommendedDishes = ["고기볶음", "양파수프", "당근라페"];

  return (
    <div className="container">
      <h1>냉장고 재료 확인</h1>
      <h2>재료 리스트 (유통기한 순)</h2>
      <ul>
        {sortedIngredients.map((ingredient, index) => (
          <li key={index}>
            {ingredient.name} - 유통기한:{" "}
            {new Date(ingredient.expiryDate).toLocaleDateString()}
          </li>
        ))}
      </ul>
      <h2>추천 요리</h2>
      <ul>
        {recommendedDishes.map((dish, index) => (
          <li key={index}>{dish}</li>
        ))}
      </ul>
    </div>
  );
}

export default FridgePage;
