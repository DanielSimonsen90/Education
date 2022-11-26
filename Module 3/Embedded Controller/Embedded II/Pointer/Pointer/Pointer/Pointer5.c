/*
 * Pointer5.c
 *
 * Created: 6/3/2021 12:33:52 PM
 *  Author: dani146d
 */ 

#include <avr/io.h>

#include "uart.h"

void PrintSize(int aTest[]);
void myPrint(char tekst[], FILE *stream);
void ConvertReceivedChar(char *ReceivedChar);

#define Upper_Lower_Bit_Position 5
#define Upper_Lower_Bit_Value (1 << Upper_Lower_Bit_Position)

int main(void)
{
	char ch; // Global variabel til udveksling af data
	char cData[] = "Pointers aren't always cool!";
	
	RS232Init();
	
	printf("\n");
	
	PrintSize(cData);
	
	printf("\n");
	
	myPrint(cData, stdout);
	
	printf("\n");

	//while(1);

	/* Replace with your application code */
	while (1)
	{
		//ch = uart_getch (stdin);
		// Hvis ikke vi havde defineret stdin funktionalitet, måtte
		// vi kalde uart_getch direkte og have styr på vores stream
		// også, hvis vi vil læse karakterer fra UART’en
		ch = getchar();
		// Nu kan vi stedet for bare nøjes med at kalde getchar funktionen
		// og så sker det hele ganske automatisk for os. Helt ligesom med
		// brugen af printf => bare den anden vej runct.
		ConvertReceivedChar(&ch);
		uart_putch(ch, stdout);
		printf("\n");
	}
}



void PrintSize(int aTest[])
{
	printf("aTest er %d bytes stort", sizeof(aTest));
}


void myPrint(char tekst[], FILE *stream)
{
	//Udskriver samtlige tegn, indtil vi rammer nul termineringen
	for(int i = 0; tekst[i] != '\0'; i++)
	{
		uart_putch(tekst[i], stream);
	}
}

void ConvertReceivedChar(char *ReceivedChar)
{
	// Den smarte måde at få konverteret små bogstaver om til store bogstaver og
	// modsat er ved brug af Xor, som vi tidligere har set. Så kan vi klare det i
	// én linje kode.
	*ReceivedChar ^= Upper_Lower_Bit_Value;

	// Vi kan også vælge at bruge den mere besværlige (og udkommenterede) metode vist
	// herunder.

	//if (*ReceivedChar & Upper_Lower_Bit_Value)
	//{
	//	*ReceivedChar = *ReceivedChar & ~Upper_Lower_Bit_Value;
	//}
	//else
	//{
	//	*ReceivedChar = *ReceivedChar | Upper_Lower_Bit_Value;
	//}
}
