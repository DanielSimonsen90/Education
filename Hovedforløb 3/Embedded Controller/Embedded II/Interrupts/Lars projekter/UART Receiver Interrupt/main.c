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
	printf("\nh3pd100120 Embedded C styrer !!!\n");
	
	Enable_UART_Receive_Interrupt();
	
	sei();					// Enable the Global Interrupt Enable flag so that interrupts can be processed
	
	
	/* Replace with your application code */
    while (1) 
    {
		// Koden herunder har intet med Interrupt at gøre. Koden er 
		// udelukkende taget med for at vise, at man i et sprog som C 
		// let kan komme til at "dumme" sig lidt. Se nærmere beskrivelse 
		// i kommentarerne inde i if blokken.
		TestVariable = 0;
		if (TestVariable == 1)
		{
			// I C programmering er det en rigtig god ide at placere konstanten
			// på venstre side i en sammenlignings operation. 
			// Dette skyldes, at programlinjen herunder er fuldt ud lovlig I C
			// if (TestVariable = 1)
			// I denne linje kode vil TestVariable få tildelt værdien 1
			// samtidig med, at man "tester" på, om værdien faktisk er 1. Denne
			// test vil således altid være opfyldt !!! Dog vil vi få en compiler 
			// warning. Men en warning kan man let overse i farten !!!
			// Vender man det hele om, vil man få 
			// en compiler fejl, hvis man glemmer et = tegn som vist i linjen herunder.
			// if (1 = TestVariable)
			// Og her er vi faktisk rigtig glade for at få en compiler fejl, da en
			// sådan fejl bliver afsløret efter 3 sekunder og ikke efter 3 måneder !!!
			
			TestVariable = 2;
		}
    }
}

