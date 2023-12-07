package com.example.social_app_intent

import android.app.Activity
import android.app.Dialog
import android.app.Instrumentation.ActivityResult
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.view.Window
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import androidx.activity.result.ActivityResultCallback
import androidx.activity.result.ActivityResultLauncher
import androidx.activity.result.contract.ActivityResultContracts
import com.example.social_app_intent.databinding.ActivityMainBinding

class MainActivity : AppCompatActivity() {

    lateinit var binding: ActivityMainBinding
    private var loggedIn: Boolean = false

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)
    }

    override fun onStart() {
        super.onStart()
        if(!loggedIn)
            showDialog()
    }

    private val selectImageLauncher = registerForActivityResult(
        ActivityResultContracts.GetContent())
    { uri ->
        binding.avatar.setImageURI(uri)
    }

    fun avatarClick(view: View) {
        selectImageLauncher.launch("image/*")
    }

    private val activityResultLauncher = registerForActivityResult(
        ActivityResultContracts.StartActivityForResult()
    ) {
        result ->
        if (result.resultCode == Activity.RESULT_OK) {
            binding.userName.text = result.data?.getStringExtra("fullname")
        }
    }

    fun nameClick(view: View) {
        activityResultLauncher.launch(Intent(this, ChangeNameActivity::class.java))
    }

    private fun showDialog() {
        val dialog = Dialog(this)
        dialog.requestWindowFeature(Window.FEATURE_NO_TITLE)
        dialog.setCancelable(false)
        dialog.setContentView(R.layout.login_layout)
        val btn = dialog.findViewById<Button>(R.id.button1)
        val login = dialog.findViewById<EditText>(R.id.login)
        val pass = dialog.findViewById<EditText>(R.id.password)
        btn.setOnClickListener {
            if(login.text.toString() == "envoid" && pass.text.toString() == "123123")
            {
                loggedIn = true
                dialog.dismiss()
            }
        }
        dialog.show()
    }
}