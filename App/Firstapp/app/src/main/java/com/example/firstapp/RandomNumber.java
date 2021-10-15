package com.example.firstapp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.widget.TextView;

import java.util.Random;

public class RandomNumber extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_random_number);

        int currentCount = getIntent().getIntExtra("com.example.firstapp.RANDOM_NUMBER", 0);
        String currentCountString = Integer.toString(currentCount);

        updateTitle(currentCountString);
        updateContent(currentCount);
    }

    private void updateTitle(String currentCount) {
        TextView title = findViewById(R.id.randomNumberText);
        String value = title.getText().toString().replace("%d", currentCount);
        title.setText(value);
    }
    private void updateContent(int currentCount) {
        TextView textView = findViewById(R.id.randomNumberContent);
        Random random = new java.util.Random();
        int randomNumber = currentCount > 0 ? random.nextInt(currentCount + 1) : 0;
        textView.setText(randomNumber);
    }
}