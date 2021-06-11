/*
 * MyTimer.c
 *
 * Created: 6/7/2021 1:30:52 PM
 *  Author: dani146d
 */ 

#include <avr/interrupt.h>

void SetupTimer() {
	printf("Setting up timer\n");
	TCCR1B |= (1 << CS12); // Select pre-scaler 256, used to divide with the clock frequence
	OCR1A |= 0xF424; //Value used to match timer value (i.e. Timer.Value == 1s) where the 1s is this value
	TCCR1B |= (1 << WGM12); //Restart interrupt timer
	
	EnableTimer();
	printf("Timer sat up\n");
}
void EnableTimer() {
	printf("Enabling timer\n");
	//UCSR0B |= (1 << RXCIE0);
	TIMSK1 |= (1 << OCIE1A); //Turn on Output Compare A
	printf("Timer enabled\n");
	
}
void DisableTimer() {
	printf("Disabling timer\n");
	
	
	
	printf("Timer disabled\n");
}

ISR(TIMER1_COMPA_vect) {
	printf("\n\nInterrupt proceeded\n\n");
	
	sei();
}