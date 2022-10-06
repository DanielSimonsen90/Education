#pragma once
#include <Ticker.h>

const char* ssid = "DanielNode";  // Enter SSID here
const char* password = "12345678";  //Enter Password here
const uint8_t max_connections = 8; //Maximum Connection Limit for AP

enum LED_STATES { OFF, ON, BLINK };
struct LED {
    uint8_t pin;
    LED_STATES state;
    String name;

    Ticker timer;
    void timer_tick();
};


ESP8266WebServer server(80);

LED Red = { 
    D7, OFF, "Red", 
};
LED Green = { D6, OFF, "Green" };