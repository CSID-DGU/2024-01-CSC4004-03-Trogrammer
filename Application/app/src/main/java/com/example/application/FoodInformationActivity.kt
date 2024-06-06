package com.example.application

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.ImageView
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class FoodInformationActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_food_search)

        val buttonMadeSelfFood = findViewById<Button>(R.id.button_make_food)
        buttonMadeSelfFood.setOnClickListener {
            val intent = Intent(this, FoodMadeSelfActivity::class.java)
            startActivity(intent)
        }

        val buttonFindRestaurant = findViewById<Button>(R.id.button_find_restaurant)
        buttonFindRestaurant.setOnClickListener {
            val intent = Intent(this, FoodSearchRestaurantActivity::class.java)
            startActivity(intent)
        }

        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.food_search)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }
    }

    private fun searchForFood(searchText: String) {
        // 검색 기능 구현 로직
        Toast.makeText(this, "Searching for: $searchText", Toast.LENGTH_SHORT).show()

        // 여기서 검색 후 이미지버튼을 누르면 FoodSearchActivity로 넘어가게 해줍니다.
        // 검색 후의 동작으로 FoodSearchActivity로 이동하도록 Intent를 설정합니다.
        val intent = Intent(this, FoodInformationActivity::class.java)
        startActivity(intent)
    }
}
