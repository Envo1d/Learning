package com.example.social_app_intent

import android.app.Activity
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import com.example.social_app_intent.databinding.ActivityChangeNameBinding

class ChangeNameActivity : AppCompatActivity() {

    lateinit var binding: ActivityChangeNameBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityChangeNameBinding.inflate(layoutInflater)
        setContentView(binding.root)
    }

    fun click(view: View) {
        val data = Intent()
        data.putExtra("fullname", binding.firstName.text.toString()
                + " " + binding.lastName.text.toString())
        setResult(Activity.RESULT_OK, data)
        finish()
    }
}