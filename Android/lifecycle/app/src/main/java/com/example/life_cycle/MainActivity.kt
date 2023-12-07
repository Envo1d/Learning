package com.example.life_cycle

import android.app.Dialog
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.view.Window
import android.widget.Button
import android.widget.EditText

class MainActivity : AppCompatActivity() {
    private val code: Int = 123123

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
    }

    override fun onResume() {
        super.onResume()
        showDialog()
    }

    private fun showDialog() {
        val dialog = Dialog(this)
        dialog.requestWindowFeature(Window.FEATURE_NO_TITLE)
        dialog.setCancelable(false)
        dialog.setContentView(R.layout.pincode)
        val btn = dialog.findViewById<Button>(R.id.button)
        val edit = dialog.findViewById<EditText>(R.id.editTextNumberPassword)
        btn.setOnClickListener {
            val editVal = edit.text.toString().toIntOrNull()
            if(editVal == code)
            {
                dialog.dismiss()
            }
        }
        dialog.show()
    }

    fun click(view: View) {
        val intent = Intent(this, AdActivity::class.java)
        startActivity(intent)
    }
}