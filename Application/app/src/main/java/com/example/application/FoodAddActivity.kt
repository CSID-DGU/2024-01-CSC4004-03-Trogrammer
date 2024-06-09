package com.example.swproject

import android.os.Bundle
import android.widget.LinearLayout
import android.widget.TextView
import android.widget.EditText
import androidx.appcompat.app.AppCompatActivity

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_food_add)

        val textView1 = findViewById<TextView>(R.id.r8y3bcwnrbzo)
        val textView2 = findViewById<TextView>(R.id.r5e4shsxmevj)
        val textView3 = findViewById<TextView>(R.id.r32q1gg5jd27)
        val textView4 = findViewById<TextView>(R.id.rjvzkj1vwiv)

        textView1.setOnClickListener {
            showEditTextDialog(textView1)
        }

        textView2.setOnClickListener {
            showEditTextDialog(textView2)
        }

        textView3.setOnClickListener {
            showEditTextDialog(textView3)
        }

        textView4.setOnClickListener {
            showEditTextDialog(textView4)
        }
    }

    private fun showEditTextDialog(textView: TextView) {
        val editText = EditText(this)
        val layout = LinearLayout.LayoutParams(
            LinearLayout.LayoutParams.MATCH_PARENT,
            LinearLayout.LayoutParams.WRAP_CONTENT
        )
        editText.layoutParams = layout
        editText.setText(textView.text.toString())

        val dialog = androidx.appcompat.app.AlertDialog.Builder(this)
            .setTitle("텍스트 입력")
            .setView(editText)
            .setPositiveButton("확인") { dialog, which ->
                textView.text = editText.text.toString()
                dialog.dismiss()
            }
            .setNegativeButton("취소") { dialog, which ->
                dialog.dismiss()
            }
            .create()

        dialog.show()
    }
}
