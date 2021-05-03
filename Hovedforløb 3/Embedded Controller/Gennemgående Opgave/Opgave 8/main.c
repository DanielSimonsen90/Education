/*
 * Opgave 8.c
 *
 * Created: 4/29/2021 12:59:38 PM
 * Author : dani146d
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>

#define BUTTON PB5 //Button set to digital pin 13
#define LEDONE PB4 //LED set to digital pin 12
#define LEDTWO PB3 //LED set to digital pin 11

#define ON(LED) PORTB |= (1<<LED) //Turn LED on
#define OFF(LED) PORTB &= ~(1<<LED) //Turn LED off
#define SWTICH_PRESSED PINB & (1<<BUTTON)

ISR(PCMSK0_vect) 
{
	if (SWTICH_PRESSED) {
		ON(LEDONE);
		OFF(LEDTWO);
	}
	else {
		OFF(LEDONE);
		ON(LEDTWO);
	}
}

int main(void)
{
	DDRB &= ~(1 << DDB5); //Enable pin 13 as input
	DDRB |= (1 << DDB4); //Enable pin 12 as output
	
	PCMSK0 |= (1<<PCINT7);
	PCICR |= (1<<PCIE0);
	
	sei();
	
	while (1)
	{

		
	}
}

