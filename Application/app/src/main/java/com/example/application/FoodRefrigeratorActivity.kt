package com.example.application

import android.widget.Button
import android.content.Intent
import android.os.Bundle
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class FoodRefrigeratorActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_food_refrigerator)

        val buttonAddFood = findViewById<Button>(R.id.refrigeratorAddFood)
        buttonAddFood.setOnClickListener {
            val intent = Intent(this, AddFoodActivity::class.java)
            startActivity(intent)
        }
        val buttonViewExpirationDate = findViewById<Button>(R.id.refrigeratorViewExpirationDate)
        buttonViewExpirationDate.setOnClickListener {
            val intent = Intent(this, ViewExpirationDateActivity::class.java)
            startActivity(intent)
        }
        val buttonRecommendRecipe = findViewById<Button>(R.id.refrigeratorRecommendRecipe)
        buttonRecommendRecipe.setOnClickListener {
            val intent = Intent(this, RecommendRecipeActivity::class.java)
            startActivity(intent)
        }

        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.food_refrigerator)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }
    }
}