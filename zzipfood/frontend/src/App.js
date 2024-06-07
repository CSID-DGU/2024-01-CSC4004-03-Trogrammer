import React from "react";
import { BrowserRouter as Router, Route, Routes, Link } from "react-router-dom";
import HomePage from "./pages/HomePage";
import FoodSearchPage from "./pages/FoodSearchPage";
import FridgePage from "./pages/FridgePage";
import "./App.css";

function App() {
  return (
    <Router>
      <div>
        <nav>
          <ul>
            <li>
              <Link to="/">메인 페이지</Link>
            </li>
            <li>
              <Link to="/food-search">먹고싶은 음식</Link>
            </li>
            <li>
              <Link to="/fridge">냉장고 재료 확인</Link>
            </li>
          </ul>
        </nav>

        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route path="/food-search" element={<FoodSearchPage />} />
          <Route path="/fridge" element={<FridgePage />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
