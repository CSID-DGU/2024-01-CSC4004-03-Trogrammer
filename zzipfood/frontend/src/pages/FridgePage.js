import React, { useState, useEffect } from "react";
import axios from "axios";

function FridgePage() {
  const [ingredients, setIngredients] = useState([]);
  const [recipes, setRecipes] = useState([]);

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

  useEffect(() => {
    if (ingredients.length > 0) {
      axios
        .get("/api/recommend-recipes")
        .then((response) => {
          setRecipes(response.data);
        })
        .catch((error) => {
          console.error("Error fetching recommended recipes:", error);
        });
    }
  }, [ingredients]);

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
        {recipes.map((recipe) => (
          <li key={recipe.name}>
            {recipe.name} ({recipe.ingredients.join(", ")})
          </li>
        ))}
      </ul>
    </div>
  );
}

export default FridgePage;
