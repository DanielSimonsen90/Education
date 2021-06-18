/*
 * MyTimer.c
 *
 * Created: 6/7/2021 1:30:52 PM
 *  Author: dani146d
 */ 

#include <avr/interrupt.h>

#include "ProjectDefines.h"
#include "MyTimerCallbacks.h"
#include "MyTimer.h"

Callbacking callbacks[3] = {
	{ TimerCallbackOne, 0, 1 },
	{ TimerCallbackTwo, 0, 1 },
	{ TimerCallbackThree, 0, 1 }
};
HercToggler hercToggle = { 'I', '0' };

uint8_t ToggleOccured(uint8_t toggle) {	
	return toggle == 1 ? 0 : 1;
}
void ConvertReceivedChar(char *ReceivedChar)
{
	//Convert upper <=> lower
	if ( ((*ReceivedChar >= 0x41) && (*ReceivedChar <= 0x5D)) ||
	     ((*ReceivedChar >= 0x61) && (*ReceivedChar <= 0x7D)))
	{
		*ReceivedChar = *ReceivedChar ^ Upper_Lower_Bit_Value;
	}
}
void HandleCallbackChange(char recievedChar) {
	uint8_t isA = recievedChar == 'A' || recievedChar == 'a' ? 1 : 0;
	uint8_t isR = recievedChar == 'R' || recievedChar == 'r' ? 1 : 0;
	
	if (isA || isR) hercToggle.state = recievedChar;
	else if (recievedChar - '0' > 0) hercToggle.cbItem = recievedChar;
	
	if (hercToggle.cbItem == 0) return;

	uint8_t index = hercToggle.cbItem - '0' - 1;
	callbacks[index].enabled = hercToggle.state == 'A' ? 1 : 0;
	printf("Callback%c is now %s.", hercToggle.cbItem, hercToggle.state == 'A' ? "enabled" : "disabled");
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

static volatile uint32_t Counter = 0;

ISR(TIMER1_COMPA_vect) {
	Counter++;
	
	for (uint8_t i = 0; i < sizeof(callbacks)/sizeof(callbacks[0]); i++)
	{
		if (callbacks[i].enabled) {
			callbacks[i].result = callbacks[i].callback(Counter);
			callbacks[i].toggle = ToggleOccured(callbacks[i].toggle);
		}
	}
	
	sei();
}

