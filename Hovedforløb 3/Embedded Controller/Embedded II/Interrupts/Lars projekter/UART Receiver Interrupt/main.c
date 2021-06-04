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
	// Den smarte m�de at f� konverteret sm� bogstaver om til store bogstaver og
	// modsat er ved brug af Xor, som vi tidligere har set. S� kan vi klare det i
	// �n linje kode.
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
		// Koden herunder har intet med Interrupt at g�re. Koden er 
		// udelukkende taget med for at vise, at man i et sprog som C 
		// let kan komme til at "dumme" sig lidt. Se n�rmere beskrivelse 
		// i kommentarerne inde i if blokken.
		TestVariable = 0;
		if (TestVariable == 1)
		{
			// I C programmering er det en rigtig god ide at placere konstanten
			// p� venstre side i en sammenlignings operation. 
			// Dette skyldes, at programlinjen herunder er fuldt ud lovlig I C
			// if (TestVariable = 1)
			// I denne linje kode vil TestVariable f� tildelt v�rdien 1
			// samtidig med, at man "tester" p�, om v�rdien faktisk er 1. Denne
			// test vil s�ledes altid v�re opfyldt !!! Dog vil vi f� en compiler 
			// warning. Men en warning kan man let overse i farten !!!
			// Vender man det hele om, vil man f� 
			// en compiler fejl, hvis man glemmer et = tegn som vist i linjen herunder.
			// if (1 = TestVariable)
			// Og her er vi faktisk rigtig glade for at f� en compiler fejl, da en
			// s�dan fejl bliver afsl�ret efter 3 sekunder og ikke efter 3 m�neder !!!
			
			TestVariable = 2;
		}
    }
}

