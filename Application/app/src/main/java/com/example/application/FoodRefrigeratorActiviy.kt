import android.content.Intent
import android.os.Bundle
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity

class FoodRefrigeratorActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_food_refrigerator)

        val foodAddTextView = findViewById<TextView>(R.id.rv5n2xi8d9v)
        val viewExpirationDateTextView = findViewById<TextView>(R.id.rk00zn5wubbl)
        val recommendRecipeTextView = findViewById<TextView>(R.id.rahdbfjyp1ap)

        foodAddTextView.setOnClickListener {
            val intent = Intent(this@FoodRefrigeratorActivity, FoodAddActivity::class.java)
            startActivity(intent)
        }

        viewExpirationDateTextView.setOnClickListener {
            val intent = Intent(this@FoodRefrigeratorActivity, ViewExpirationDateActivity::class.java)
            startActivity(intent)
        }

        recommendRecipeTextView.setOnClickListener {
            val intent = Intent(this@FoodRefrigeratorActivity, RecommendRecipeActivity::class.java)
            startActivity(intent)
        }
    }
}
