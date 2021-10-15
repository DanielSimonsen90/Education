package com.example.firstapp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import org.w3c.dom.Text;

public class DisplayMessageActivity extends AppCompatActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_display_message);

        // Get the Intent that started this activity and extract the string
        Intent intent = getIntent();
        String message = intent.getStringExtra(MainActivity.EXTRA_MESSAGE);

        // Capture the layout's TextView and set the string as its text
        TextView textView = findViewById(R.id.textView);
        textView.setText(message);
    }

    public void onToastClick(View view) {
        Toast toast = Toast.makeText(this, "You clicked on the toast!", Toast.LENGTH_SHORT);
        toast.show();
    }
    public void onCountClick(View view) {
        Button btnCount = (Button)this.findViewById(R.id.btnCount);
        Integer count = Integer.parseInt(btnCount.getText().toString());
        btnCount.setText("Count: " + count++);
    }
    public void onNextClick(View view) {
        int currentCount = Integer.parseInt(((Button)this.findViewById((R.id.btnCount))).getText().toString());
        Intent intent = new Intent(this, RandomNumber.class);
        intent.putExtra("com.example.firstapp.RANDOM_NUMBER", currentCount);
        startActivity(intent);
    }
}