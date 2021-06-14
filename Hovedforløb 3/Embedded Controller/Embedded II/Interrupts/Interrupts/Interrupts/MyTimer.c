/*
 * MyTimer.c
 *
 * Created: 6/7/2021 1:30:52 PM
 *  Author: dani146d
 */ 

#include <avr/interrupt.h>
#include "MyTimer.h"

uint32_t Counter = 0;
#define LED PB0 //digitalPin 8

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
	printf("\n%ld", Counter);
	LED ^= (1 << PB0);
	
	sei();
}