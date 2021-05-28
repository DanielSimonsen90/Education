/*
 * Opgave 4 & 5a
 *
 * Created: 4/29/2021 11:11:56 AM
 * Author : dani146d
 */ 

#include <avr/io.h>
#include <util/delay.h>

#define ON() PORTB |= (1<<PB0)
#define OFF() PORTB &= ~(1<<PB0)

int main(void)
{
    while (1) 
    {
		ON();				//Turn on LED
		_delay_ms(500);		//wait 500ms
		OFF();				//Turn off LED
		_delay_ms(500);		//wait 500ms
    }
}

