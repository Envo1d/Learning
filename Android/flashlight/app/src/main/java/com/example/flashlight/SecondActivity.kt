package com.example.flashlight

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import androidx.constraintlayout.widget.ConstraintLayout
import androidx.core.content.ContextCompat

class SecondActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_second)

        val color = intent.getStringExtra("color")

        val layout = findViewById<ConstraintLayout>(R.id.layout)

        when(color) {
            "white" -> layout.setBackgroundColor(ContextCompat.getColor(this, R.color.white))
            "blue" -> layout.setBackgroundColor(ContextCompat.getColor(this, R.color.blue))
            "red" -> layout.setBackgroundColor(ContextCompat.getColor(this, R.color.red))
            "green" -> layout.setBackgroundColor(ContextCompat.getColor(this, R.color.green))
            "magenta" -> layout.setBackgroundColor(ContextCompat.getColor(this, R.color.magenta))
            "lightGray" -> layout.setBackgroundColor(ContextCompat.getColor(this, R.color.light_gray))
            "cyan" -> layout.setBackgroundColor(ContextCompat.getColor(this, R.color.cyan))

        }
    }
}