/*
 * UART.c
 * Version: 1.0
 * Created: 25-02-2015 20:10:21
 * Author: alkj
 */ 

#include <avr/io.h>
#include <avr/interrupt.h>

#include "ProjectDefines.h"
#include "UART.h"
#include "Main.h"

//static FILE mystdInOut = FDEV_SETUP_STREAM(uart_putch, uart_getch, _FDEV_SETUP_RW);
// Hvis man fortrækker det, kan man også splitte sine streams op i en seperat stream i
// udgående retning og en seperat stream i indgående retning som vist herunder. Effekten
// er den samme !!!
static FILE uart_output = FDEV_SETUP_STREAM(uart_putch, NULL, _FDEV_SETUP_WRITE);
static FILE uart_input = FDEV_SETUP_STREAM(NULL, uart_getch, _FDEV_SETUP_READ);


void RS232Init( void)
{
	// Set baud rate
	UBRR0L = (unsigned char)(MyUBRR & 0xff);
	UBRR0H = (unsigned char)(MyUBRR>>8);
#ifdef UART_NORMAL_MODE	
	UCSR0A = 0x00;
#else
	UCSR0A = 1<<U2X0; // Set *2 mode
#endif
	UCSR0B = (1<<RXEN0) | (1<<TXEN0);  //0x18 , enable receive and transmit
	UCSR0C =  (1<<UCSZ01) | (1<<UCSZ00); // 8 data bit 1 stop bit
	SetupOutputStreamToUart();
	SetupInputStreamToUart();
}

void SetupOutputStreamToUart(void)
{
	stdout = &uart_output;
}

void SetupInputStreamToUart(void)
{
	stdin = &uart_input;
}


int uart_getch(FILE* stream)
{
	while( !(UCSR0A & (1<<RXC0)))  ; // do nothing but wait
	return( UDR0);
}

int uart_putch(char ch, FILE* stream)
{
	while( !(UCSR0A & (1<<UDRE0))) ;
	UDR0 = ch;
	return 0;
}

void Enable_UART_Receive_Interrupt()
{
	UCSR0B |= (1 << RXCIE0); // Enable the USART Recieve Complete interrupt (USART_RXC)
}

void Disable_UART_Receive_Interupt()
{
	UCSR0B &= ~(1 << RXCIE0); // Disable the USART Recieve Complete interrupt (USART_RXC)
}

ISR(USR0_Vect_Num)
{
	char ReceivedByte;
	ReceivedByte = UDR0;
	ConvertReceivedChar(&ReceivedByte);
	UDR0 = ReceivedByte; // Echo back the received byte converted to the computer
	sei();
}

