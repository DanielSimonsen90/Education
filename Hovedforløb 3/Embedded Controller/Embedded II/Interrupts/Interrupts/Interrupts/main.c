/*
 * Interrupts.c
 *
 * Created: 6/4/2021 10:11:46 AM
 * Author : dani146d
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>
#include <avr/delay.h>
#include "UART.h"

#define setBit(reg, bit) (reg = reg | (1 << bit))
#define clearBit(reg, bit) (reg = reg & ~(1 << bit))
#define toggleBit(reg, bit) (reg = reg ^ (1 << bit))
#define clearFlag(reg, bit) (reg = reg | (1 << bit))

int main(void)
{
	RS232Init();
	Enable_UART_Receive_Interrupt();
	sei();
	
	
	
	while (1) 
	{
		_delay_ms(1000);
		//call interrupt
	}
}

