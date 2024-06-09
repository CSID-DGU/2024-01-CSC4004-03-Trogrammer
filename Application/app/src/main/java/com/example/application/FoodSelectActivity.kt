package com.example.application


import android.content.Intent
import android.os.Bundle
import android.widget.EditText
import android.widget.ImageView
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class FoodSelectActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_food_main)

        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.food_main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val searchFoodEditText = findViewById<EditText>(R.id.search_food_edit_text)
        val searchFoodIcon = findViewById<ImageView>(R.id.search_food_icon)
        val searchFoodEditText = findViewById<EditText>(R.id.search_food_edit_text)
        val searchFoodIcon = findViewById<ImageView>(R.id.search_food_icon)
        val searchImageButton = findViewById<ImageView>(R.id.search_food_icon)

        // 검색 아이콘 클릭 리스너 설정
        searchFoodIcon.setOnClickListener {
            val searchText = searchFoodEditText.text.toString()
            // 검색 기능 구현
            searchForFood(searchText)
        }

        // 이미지 버튼 클릭 리스너 설정
        searchImageButton.setOnClickListener {
            // FoodInformationActivity로 이동
            val intent = Intent(this, FoodInformationActivity::class.java)
            startActivity(intent)
        }

        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.food_main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

    }

    private fun searchForFood(searchText: String) {
        // 검색 기능 구현 로직
        Toast.makeText(this, "Searching for: $searchText", Toast.LENGTH_SHORT).show()
        // 여기서 실제 검색 기능을 구현할 수 있습니다.
    }
}
