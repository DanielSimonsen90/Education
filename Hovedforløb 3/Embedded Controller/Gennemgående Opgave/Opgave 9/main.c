/*
 * Opgave 9.c
 *
 * Created: 4/29/2021 1:17:49 PM
 * Author : dani146d
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>

#define LED PB4 //LED set to digital pin 12
#define ON() PORTB |= (1<<LED) //Turn LED on
#define OFF() PORTB &= ~(1<<LED) //Turn LED off
#define LED_Toggle PINB |= (1<<LED) //Toggle between ON/OFF

ISR(ADC_vect) {
	LED_Toggle;
}

void ADC_init(void) {
	ADMUX |= (1<<REFS0) | (1<<MUX0);
	ADCSRA |= (1<<ADEN) | (1<<ADSC) | (1<<ADATE) | (1<<ADIE) | (1<<ADPS2) | (1<<ADPS1)
	sei();
}

int main(void)
{
	DDRB |= (1 << DDB4); //Enable pin 12 as output
	ADC_init();
	
    while (1) 
    {
    }
}

