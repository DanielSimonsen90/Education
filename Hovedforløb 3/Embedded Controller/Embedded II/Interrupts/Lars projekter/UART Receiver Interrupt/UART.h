/*
 * UART.h
 * Created: 25-02-2015 20:8:13
 * Version: 1.0
 * Author: alkj
 */ 
#ifndef __UART_H__
#define __UART_H__

#include <stdio.h>
#include "Arduino.h"
#define BAUD 9600UL

#define UART_NORMAL_MODE
#ifdef UART_NORMAL_MODE
#define MyUBRR (unsigned int)(F_CPU/(16*BAUD) -1)   // normal mode
#else
#define MyUBRR (unsigned int)(F_CPU/(8*BAUD) -1)   // *2 mode
#endif

extern void RS232Init( void);

extern int uart_getch(FILE*stream);

extern int uart_putch(char ch, FILE*stream);

extern void SetupOutputStreamToUart(void);

extern void SetupInputStreamToUart(void);

extern void Enable_UART_Receive_Interrupt();
extern void Disable_UART_Receive_Interupt();

#endif // __UART_H__
