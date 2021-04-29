/*
 * Opgave 7.c
 *
 * Created: 4/29/2021 12:47:25 PM
 * Author : dani146d
 */ 

#include <avr/io.h>
#define BUTTON PB5 //Button set to digital pin 13
#define LED PB4 //LED set to digital pin 12
#define ON() PORTB |= (1<<LED) //Turn LED on
#define OFF() PORTB &= ~(1<<LED) //Turn LED off

int main(void)
{
	DDRB &= ~(1 << DDB5); //Enable pin 13 as input
	DDRB |= (1 << DDB4); //Enable pin 12 as output
	
    while (1) 
    {
		if (PINB & (1<<BUTTON)) {
			ON();
		}
		else {
			OFF();
		}
		
    }
}

