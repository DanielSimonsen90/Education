#include <ESP8266WiFi.h>
#include <ESP8266WebServer.h>

/* Put your SSID & Password */
const char* ssid = "reeee";  // Enter SSID here
const char* password = "12345678";  //Enter Password here
uint8_t max_connections = 8;//Maximum Connection Limit for AP
int current_stations = 0, new_stations = 0;

ESP8266WebServer server(80);

uint8_t LED1pin = D7;
bool LED1status = LOW;

uint8_t LED2pin = D6;
bool LED2status = LOW;

void setup() {
    Serial.begin(115200);

    //Output mode fot the LED pins
    pinMode(LED1pin, OUTPUT);
    pinMode(LED2pin, OUTPUT);

    //Setting the AP Mode with SSID, Password, and Max Connection Limit
    if (WiFi.softAP(ssid, password, 1, false, max_connections) == true)
    {
        Serial.println("Access Point is Created with SSID: " + String(ssid));
        Serial.println("Max Connections Allowed: " + String(max_connections));
        Serial.println("Access Point IP: " + WiFi.softAPIP().toString());
    }
    else Serial.println("Unable to Create Access Point");

    server.on("/", onConnect);
    server.on("/led1on", []() { onLedOn(&LED1status, "Red"); });
    server.on("/led1off", []() { onLedOff(&LED1status, "Red"); });
    server.on("/led2on", []() { onLedOn(&LED2status, "Green"); });
    server.on("/led2off", []() {  onLedOff(&LED2status, "Green"); });
    server.onNotFound([]() { server.send(404, "text/plain", "Not found"); });

    server.begin();
    Serial.println("HTTP server started");
}

void loop() {
    server.handleClient();

    digitalWrite(LED1pin, LED1status ? HIGH : LOW);
    digitalWrite(LED2pin, LED2status ? HIGH : LOW);
}

void onConnect() {
    LED1status = LOW;
    LED2status = LOW;
    Serial.println("Red: OFF | Green: OFF");
    server.send(200, "text/html", SendHTML(LED1status, LED2status));
}

void onLedOn(bool* led, String name) {
    *led = HIGH;
    Serial.println(name + ": ON");
    server.send(200, "text/html", SendHTML(LED1status, LED2status));
}
void onLedOff(bool* led, String name) {
    *led = LOW;
    Serial.println(name + ": OFF");
    server.send(200, "text/html", SendHTML(LED1status, LED2status));
}

String SendHTML(uint8_t led1stat, uint8_t led2stat) {
    String ptr = "<!DOCTYPE html> <html>\n";
    ptr += "<head><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, user-scalable=no\">\n";
    ptr += "<title>LED Control</title>\n";
    ptr += "<style>html { font-family: Helvetica; display: inline-block; margin: 0px auto; text-align: center;}\n";
    ptr += "body{margin-top: 50px;} h1 {color: #444444;margin: 50px auto 30px;} h3 {color: #444444;margin-bottom: 50px;}\n";
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

	ptr += led1stat ? 
        "<p>LED1 Status: ON</p><a class=\"button button-off\" href=\"/led1off\">OFF</a>\n" :
        "<p>LED1 Status: OFF</p><a class=\"button button-on\" href=\"/led1on\">ON</a>\n";
    ptr += led2stat ?
        "<p>LED2 Status: ON</p><a class=\"button button-off\" href=\"/led2off\">OFF</a>\n" :
        "<p>LED2 Status: OFF</p><a class=\"button button-on\" href=\"/led2on\">ON</a>\n";

    ptr += "</body>\n";
    ptr += "</html>\n";
    return ptr;
}