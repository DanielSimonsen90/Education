/*
 * Interrupts.c
 *
 * Created: 6/4/2021 10:11:46 AM
 * Author : dani146d
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>
#include "UART.h"
#include "MyTimer.h"

int main(void)
{
	RS232Init();
	Enable_UART_Receive_Interrupt();
	SetupTimer();
	sei();
	
	while (1) 
	{
	}
}

