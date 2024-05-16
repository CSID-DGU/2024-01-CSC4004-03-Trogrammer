CREATE DATABASE FoodDatabase;
USE FoodDatabase;

CREATE TABLE Users (
    UserID INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL,
    FavoriteFood VARCHAR(50)
);

CREATE TABLE Foods (
    FoodID INT AUTO_INCREMENT PRIMARY KEY,
    FoodName VARCHAR(50) NOT NULL,
    FoodCategory VARCHAR(50),
    DiningPrice DECIMAL(10, 2),
    CookingCost DECIMAL(10, 2)
);

CREATE TABLE Alcohols (
    AlcoholID INT AUTO_INCREMENT PRIMARY KEY,
    AlcoholName VARCHAR(50) NOT NULL,
    RecommendedFoodCategory VARCHAR(50),
    FOREIGN KEY (RecommendedFoodCategory) REFERENCES Foods(FoodCategory)
);

CREATE TABLE Recipes (
    RecipeID INT AUTO_INCREMENT PRIMARY KEY,
    RecipeName VARCHAR(50) NOT NULL,
    RecipeDescription TEXT,
    CookingTime INT
);

CREATE TABLE Recipe_Ingredients (
    RecipeID INT,
    IngredientID INT AUTO_INCREMENT PRIMARY KEY,
    RequiredQuantity INT,
    FOREIGN KEY (RecipeID) REFERENCES Recipes(RecipeID)
);

CREATE TABLE Refrigerator_Ingredients (
    RefrigeratorIngredientID INT AUTO_INCREMENT PRIMARY KEY,
    IngredientName VARCHAR(50) NOT NULL,
    Quantity INT,
    ExpirationDate DATE
);
