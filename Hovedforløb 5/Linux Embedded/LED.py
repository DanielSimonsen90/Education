import RPi.GPIO as GPIO
from enum import Enum
from threading import Timer

class LED_STATES(Enum):
    OFF = 0
    ON = 1
    BLINK = 2

DEFAULT_INTERVAL = 1
    
class LED:
    def __init__(self, pin, state = LED_STATES.OFF, interval = DEFAULT_INTERVAL):
        self.pin = pin
        self.state = state
        self.interval = interval

        self.timer = Timer(interval, self.on_timer_tick)
        self.has_timer_running = False

        if self.state == LED_STATES.BLINK: self.blink()
        
        GPIO.setmode(GPIO.BCM)
        GPIO.setup(self.pin, GPIO.OUT)
    
    def on(self):
        self.state = LED_STATES.ON
        GPIO.output(self.pin, GPIO.HIGH)
    
    def off(self):
        self.state = LED_STATES.OFF
        GPIO.output(self.pin, GPIO.LOW)

    def blink(self, interval = DEFAULT_INTERVAL):
        if (self.state == LED_STATES.BLINK 
            and interval == self.interval 
            and self.has_timer_running): return
        elif self.has_timer_running: return self.timer.run()

        self.state = LED_STATES.BLINK
        self.interval = interval if interval != DEFAULT_INTERVAL else self.interval
        self.timer = Timer(self.interval, self.on_timer_tick)
        self.timer.start()
        self.has_timer_running = True

    def on_timer_tick(self):
        GPIO.output(self.pin, GPIO.HIGH if GPIO.input(self.pin) == GPIO.LOW else GPIO.LOW)
        self.timer.run()


    def switch_state(self):
        switch = {
            LED_STATES.ON: LED_STATES.BLINK,
            LED_STATES.BLINK: LED_STATES.OFF,
            LED_STATES.OFF: LED_STATES.ON
        }
        self.state = switch.get(self.state, LED_STATES.OFF)

        
    def update(self):
        if self.state == LED_STATES.ON: self.on()
        elif self.state == LED_STATES.OFF: self.off()
        elif self.state == LED_STATES.BLINK and not self.has_timer_running: self.blink(self.interval)
        
        if self.state != LED_STATES.BLINK and self.has_timer_running: 
            self.timer.cancel()
            self.has_timer_running = False
