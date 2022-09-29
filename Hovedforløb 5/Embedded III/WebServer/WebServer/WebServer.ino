#include <ESP8266WiFi.h>
#include <ESP8266WebServer.h>
#include "WebServer.h"

const char* ssid = "DanielNode";  // Enter SSID here
const char* password = "12345678";  //Enter Password here
uint8_t max_connections = 8; //Maximum Connection Limit for AP
enum LED_STATES { OFF, ON, BLINK };
struct LED {
    uint8_t pin; 
	uint8_t state;
    String name;
};

#define SizeOfArray(arr)  (sizeof(arr)/sizeof(arr[0]))

ESP8266WebServer server(80);

LED Red = { D7, OFF, "Red" };
LED Green = { D6, OFF, "Green" };

void setup() {
    Serial.begin(115200);

    //Output mode fot the LED pins
    pinMode(Red.pin, OUTPUT);
    pinMode(Green.pin, OUTPUT);

    //Setting the AP Mode with SSID, Password, and Max Connection Limit
    if (WiFi.softAP(ssid, password, 1, false, max_connections) == true)
    {
        Serial.println("Access Point is Created with SSID: " + String(ssid));
        Serial.println("Max Connections Allowed: " + String(max_connections));
        Serial.println("Access Point IP: " + WiFi.softAPIP().toString());
    }
    else Serial.println("Unable to Create Access Point");

	// []() { //code here } indicates delegate

    server.on("/", onConnect);
    server.on("/redon", []() { onLedOn(&Red); });
    server.on("/redoff", []() { onLedOff(&Red); });
    server.on("/redblink", []() { onLedBlink(&Red); });

    server.on("/greenon", []() { onLedOn(&Green); });
    server.on("/greenoff", []() {  onLedOff(&Green); });
    server.on("/greenblink", []() { onLedBlink(&Green); });
	
    server.onNotFound([]() { server.send(404, "text/plain", "Not found"); });

    server.begin();
    Serial.println("HTTP server started");
}

void loop() {
    server.handleClient();

	digitalWrite(Red.pin, getLedState(Red));
    digitalWrite(Green.pin, getLedState(Green));
    delay(1000);
}

void onConnect() {
    Red.state = ON;
    Green.state = BLINK;
    Serial.println("Red: OFF | Green: OFF");
    server.send(200, "text/html", SendHTML());
}

bool getLedState(LED led) {
    switch (led.state)
    {
	    case ON: return true;
	    case OFF: return false;
	    case BLINK: return digitalRead(led.pin) == 0;
    }
    return false;
}

void onLedOn(LED *led) {
    led->state = ON;
    Serial.println(led->name + ": ON");
    server.send(200, "text/html", SendHTML());
}
void onLedOff(LED *led) {
    led->state = OFF;
    Serial.println(led->name + ": OFF");
    server.send(200, "text/html", SendHTML());
}
void onLedBlink(LED *led) {
	led->state = BLINK;
	Serial.println(led->name + ": BLINK");
	server.send(200, "text/html", SendHTML());
}
String SendHTML() {
    String ptr = "<!DOCTYPE html> <html>\n";
    ptr += "<head><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, user-scalable=no\">\n";
    ptr += "<title>LED Control</title>\n";
    ptr += "<style>html { font-family: Helvetica; display: inline-block; margin: 0px auto; text-align: center;}\n";
    ptr += "body{margin-top: 50px; margin-inline: auto; max-width:75vw;} h1 {color: #444444;margin: 50px auto 30px;} h3 {color: #444444;margin-bottom: 50px;}\n";
    ptr += "main {display: flex; gap:1em; justify-content:center;}";
    ptr += ".container {display:flex; flex-direction:column; gap:.5em;}";
    ptr += ".button {display: block;width: 80px;background-color: #1abc9c;border: none;color: white;padding: 13px 30px;text-decoration: none;font-size: 25px;margin: 0px auto 35px;cursor: pointer;border-radius: 4px;}\n";
    ptr += ".button-on {background-color: #1abc9c;}\n";
    ptr += ".button-on:active {background-color: #16a085;}\n";
    ptr += ".button-off {background-color: #34495e;}\n";
    ptr += ".button-off:active {background-color: #2c3e50;}\n";
    ptr += "p {font-size: 14px;color: #888;margin-bottom: 10px;}\n";
    ptr += "</style>\n";
    ptr += "</head>\n";
    ptr += "<body>\n";
    ptr += "<h1>ESP8266 Web Server</h1>\n";
    ptr += "<h3>Using Access Point(AP) Mode</h3>\n";
    ptr += "<main>";

    LED leds[2] = { //&Red, &Green };
        Red.pin, Red.state, Red.name, 
        Green.pin, Green.state, Green.name 
    };
    String states[] = { "ON", "BLINK", "OFF" };

    for (uint8_t ledIndex = 0; ledIndex < SizeOfArray(leds); ledIndex++)
    {
        LED led = leds[ledIndex];
        String stringState = led.state == ON ? "ON" : led.state == OFF ? "OFF" : "BLINK";
        ptr += "<div class=\"container\">";
        ptr += "<p>" + led.name + " Status: " + stringState + "</p>\n";
		
        stringState.toLowerCase();
        for (uint8_t stateIndex = 0; stateIndex < SizeOfArray(states); stateIndex++)
        {
            ptr += GetLEDButton(led, stringState, states[stateIndex]);
        }
		
		ptr += "</div>";
    }

    ptr += "</main>\n";
    ptr += "</body>\n";
    ptr += "</html>\n";

    return ptr;
}
String GetLEDButton(LED led, String stringStateLower, String clickState) {
    String clickStateLower = String(clickState);
    
    clickState.toUpperCase();
    clickStateLower.toLowerCase();
    String lowerName = String(led.name);
    lowerName.toLowerCase();
	
    String buttonClass = clickStateLower == stringStateLower ? "off" : "on";
    String result = (
        "<a class=\"button button-" + buttonClass +
            "\" href=\"/" + lowerName + clickStateLower + "\">" +
		    clickState +
		"</a>\n"
    );
	
    return result;
}