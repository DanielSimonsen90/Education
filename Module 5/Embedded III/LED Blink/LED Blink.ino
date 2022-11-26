// Visual Micro is in vMicro>General>Tutorial Mode
// 
/*
    Name:       LED Blink.ino
    Created:	20-09-2022 12:08:56
    Author:     SKPDATA\dani146d
*/

// Define User Types below here or use a .h file
//


// Define Function Prototypes that use User Types below here or use a .h file
//


// Define Functions below here or use other .ino or cpp files
//

// The setup() function runs once each time the micro-controller starts
void setup()
{
    pinMode(D7, OUTPUT);
}

// Add the main program code into the continuous loop() function
void loop()
{
    digitalWrite(D7, HIGH);
    delay(1000);
    digitalWrite(D7, LOW);
    delay(1000);
}
