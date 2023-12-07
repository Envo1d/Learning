package com.example.flashlight

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        setContentView(R.layout.activity_main)
    }

    fun colorPick(v: View) {
        val color = v.context.resources.getResourceEntryName(v.id)
        val intent = Intent(this, SecondActivity::class.java)
        intent.putExtra("color", color)
        startActivity(intent)
    }
}