/*
 * Opgave 11.c
 *
 * Created: 4/29/2021 1:18:26 PM
 * Author : dani146d
 */ 

#include <avr/io.h>
#define FOSC 16000000 //Clock Speed
#define BAUD 9600
#define MYUBRR FOSC / 16 / BAUD - 1

unsigned char USART_receive(void) {
	//Wait for data to be received
	while (!(UCSR0A & (1<<RXC0)));
	//Get and return buffer
	return UDR0;
}

void USART_transmit(unsigned char cmd) {
	//Wait for empty transmit buffer
	while(!(UCSR0A & (1<<UDRE0)));
	UDR0 = cmd;
}

void USART_Init (unsigned int ubrr) {
	//Set baud rate
	UBRR0H = (unsigned char)(ubrr>>8);
	UBRR0L = (unsigned char)ubrr;
	//Enable receiver and transmitter
	UCSR0B = (1<<RXEN0) | (1<<TXEN0);
	//Set frame format: 8data, 2stop bit
	UCSR0C = (1<<USBS0) | (3<<UCSZ00);
}
int main(void)
{
	USART_Init(MYUBRR);
	
	while (1)
	{
		USART_transmit(USART_receive());
	}
}


