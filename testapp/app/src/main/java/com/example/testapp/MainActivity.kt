package com.example.yourapp

import android.R
import android.content.Intent
import android.os.Bundle
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import com.example.swproject.FoodRefrigeratorActivity

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val textView1 = findViewById<TextView>(R.id.rfbpsac7wztp)
        textView1.setOnClickListener {
            val intent = Intent(
                this@MainActivity,
                FoodRefrigeratorActivity::class.java
            )
            startActivity(intent)
        }

        val textView2 = findViewById<TextView>(R.id.rd4p0s5ybnm)
        textView2.setOnClickListener {
            val intent = Intent(
                this@MainActivity,
                FoodSearchActivity::class.java
            )
            startActivity(intent)
        }
    }
}