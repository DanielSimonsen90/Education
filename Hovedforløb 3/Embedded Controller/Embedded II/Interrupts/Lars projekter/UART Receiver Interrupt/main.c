/*
 * h3pd040120_Uart_Interrupt_C.c
 *
 * Created: 10-05-2020 21:32:54
 * Author : ltpe
 */ 

#include <avr/io.h>
#include <string.h>
#include <stdio.h>
#include <avr/interrupt.h>
#include "uart.h"
#include "ProjectDefines.h"

void ConvertReceivedChar(char *ReceivedChar)
{
	// Den smarte måde at få konverteret små bogstaver om til store bogstaver og
	// modsat er ved brug af Xor, som vi tidligere har set. Så kan vi klare det i
	// én linje kode.
	//*ReceivedChar ^= Upper_Lower_Bit_Value;
	if ( ((*ReceivedChar >= 0x41) && (*ReceivedChar <= 0x5D)) ||
	     ((*ReceivedChar >= 0x61) && (*ReceivedChar <= 0x7D)))
	{
		*ReceivedChar = *ReceivedChar ^ Upper_Lower_Bit_Value;
	}
}


int main(void)
{
	volatile uint8_t TestVariable;
	RS232Init();
	printf("\nHello, world\n");
	
	Enable_UART_Receive_Interrupt();
	
	sei();					// Enable the Global Interrupt Enable flag so that interrupts can be processed
	
    while (1) 
    {
		TestVariable = 0; 
		
		if (TestVariable == 1)
		{	
			TestVariable = 2;
		}
    }
}

