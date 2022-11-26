import time, RPi.GPIO as GPIO

from LED import LED, LED_STATES
from Button import Button

GPIO.setwarnings(False) # Disable warnings when using GPIO pins
GPIO.setmode(GPIO.BCM) # Tell GPIO we're using BCM mode

def on_button_pressed():
    red.switch_state()

red = LED(26) # Red LED on GPIO 26
green = LED(19, LED_STATES.BLINK) # Green LED on GPIO 19
button = Button(24, on_button_pressed) # Button on GPIO 24

while True:
    button.update()
    red.update()
    green.update()
    time.sleep(.1)