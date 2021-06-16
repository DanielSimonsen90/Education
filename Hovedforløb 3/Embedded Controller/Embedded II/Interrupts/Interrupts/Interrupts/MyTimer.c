/*
 * MyTimer.c
 *
 * Created: 6/7/2021 1:30:52 PM
 *  Author: dani146d
 */ 

#include <avr/interrupt.h>
#include "MyTimer.h"
#include "MyTimerCallbacks.h"

#define LED PB0 //digitalPin 8
typedef void (*TimerCallback)(int);
TimerCallback callbacks[3] = { TimerCallbackOne, TimerCallbackTwo, TimerCallbackThree };
int Counter = 0;

void SetupTimer() {
	TCCR1B |= (1 << CS12); // Select pre-scaler 256, used to divide with the clock frequence
	OCR1A |= 0xF424; //Value used to match timer value (i.e. Timer.Value == 1s) where the 1s is this value
	TCCR1B |= (1 << WGM12); //Restart interrupt timer
	
	DDRB |= (1 << DDB0);
	
	EnableTimer();
}
void EnableTimer() {
	TIMSK1 |= (1 << OCIE1A); //Turn on Output Compare A
}
void DisableTimer() {
	TIMSK1 &= ~(1 << OCIE1A); //Turn off Output Compare A
}

ISR(TIMER1_COMPA_vect) {
	Counter++;
	PORTB ^= (1 << LED);
	
	int i;
	for (i = 0; i < sizeof(callbacks)/sizeof(int); i++)
	{
		callbacks[i](Counter);
	}
	
	sei();
}

