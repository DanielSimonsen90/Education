/*
 * MyTimer.c
 *
 * Created: 6/7/2021 1:30:52 PM
 *  Author: dani146d
 */ 

#include <avr/interrupt.h>

#include "DanielTypes.h"
#include "ProjectDefines.h"
#include "MyTimer.h"
#include "MyTimerCallbacks.h"

Callbacking callbacks[3] = {
	{ TimerCallbackOne, 0 },
	{ TimerCallbackTwo, 0 },
	{ TimerCallbackThree, 0 }
};

uint8_t ToggleOccured(uint8_t toggle) {	
	return toggle == 1 ? 0 : 1;
}
void ConvertReceivedChar(char *ReceivedChar)
{
	if ( ((*ReceivedChar >= 0x41) && (*ReceivedChar <= 0x5D)) ||
	     ((*ReceivedChar >= 0x61) && (*ReceivedChar <= 0x7D)))
	{
		*ReceivedChar = *ReceivedChar ^ Upper_Lower_Bit_Value;
	}
}


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
	for (uint8_t i = 0; i < sizeof(callbacks)/sizeof(callbacks[0]); i++)
	{
		callbacks[i].result = callbacks[i].callback(callbacks[i]);
		callbacks[i].toggle = ToggleOccured(callbacks[i].toggle);
	}
	
	sei();
}

