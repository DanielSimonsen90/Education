/*
 * Opgave 6.c
 *
 * Created: 4/29/2021 12:41:49 PM
 * Author : dani146d
 */ 

#include <avr/io.h>
#include <util/delay.h>

#define LED PB0 //Create variable LED as PD0
#define ON() PORTB |= (1<<LED) //Turn LED ON
#define OFF() PORTB &= ~(1<<LED) //Turn LED OFF
#define TIME 0b01100100 //100(ms)

int main(void)
{
	while (1)
	{
		ON();						//Turn on LED
		_delay_ms(10 * TIME);		//wait 1000ms
		OFF();						//Turn off LED
		_delay_ms(5 * TIME);		//wait 500ms
	}
}

