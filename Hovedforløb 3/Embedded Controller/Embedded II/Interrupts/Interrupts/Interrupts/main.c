/*
 * Interrupts.c
 *
 * Created: 6/4/2021 10:11:46 AM
 * Author : dani146d
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>

#include "DanielTypes.h"
#include "UART.h"
#include "MyTimer.h"

int main(void)
{
	RS232Init();
	Enable_UART_Receive_Interrupt();
	SetupTimer();
	sei();
	
	uint8_t newLine = 0;
	while (1) 
	{
		for (uint8_t i = 0; i < sizeof(callbacks)/sizeof(callbacks[0]); i++)
		{
			if (callbacks[i].toggle == 1) {
				printf("Callback%d true. Result: %d\n", i + 1, callbacks[i].result);
				callbacks[i].toggle = ToggleOccured(callbacks[i].toggle);
				newLine = 1;
			}
		}
		if (newLine	== 1)
		{
			printf("\n");
			newLine = 0;
		}
	}
}

