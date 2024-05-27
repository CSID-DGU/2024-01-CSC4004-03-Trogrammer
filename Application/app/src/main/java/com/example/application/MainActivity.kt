package com.example.application

import android.widget.Button
import android.content.Intent
import android.os.Bundle
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)

        val buttonMakingFood = findViewById<Button>(R.id.mainMakingFood)
        buttonMakingFood.setOnClickListener {
            val intent = Intent(this, FoodRefrigeratorActivity::class.java)
            startActivity(intent)
        }
        //val buttonChooseFood = findViewById<Button>(R.id.mainChooseFood)
        //buttonChooseFood.setOnClickListener {
        //    val intent = Intent(this, ViewExpirationDateActivity::class.java)
        //    startActivity(intent)
        //}

        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }
    }
}