import React from "react";
import "../App.css";

function HomePage() {
  return (
    <div className="container">
      <h1>자취생의 식탁</h1>
      <p>원하는 기능을 선택하세요:</p>
      <ul>
        <li>먹고싶은 음식 검색</li>
        <li>냉장고 재료 확인</li>
      </ul>
    </div>
  );
}

export default HomePage;
