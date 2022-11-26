import RPi.GPIO as GPIO
import time

class Button:
    def __init__(self, pin, on_pressed):
        self.pin = pin
        self.on_pressed = on_pressed
        self.times_pressed = 0

        GPIO.setmode(GPIO.BCM)
        GPIO.setup(self.pin, GPIO.IN, pull_up_down=GPIO.PUD_UP)
    
    def update(self):
        if GPIO.input(self.pin) == GPIO.HIGH: return

        self.times_pressed += 1
        print(f"Button pressed {self.times_pressed} times")

        self.on_pressed()
        time.sleep(.25)