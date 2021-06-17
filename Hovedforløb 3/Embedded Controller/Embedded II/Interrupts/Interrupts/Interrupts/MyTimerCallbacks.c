/*
 * MyTimerCallbacks.c
 *
 * Created: 16-06-2021 13:41:12
 *  Author: dani146d
 */ 

#include "DanielTypes.h"

//int Counter = 0;
static volatile uint32_t Counter = 0;
#define LED PB0 //digitalPin 8

uint32_t TimerCallbackOne(Callbacking cb)
{
	Counter++;
	
	return Counter;
}

uint32_t TimerCallbackTwo(Callbacking cb) 
{
	PORTB ^= (1 << LED);
	return LED;
}

uint32_t TimerCallbackThree(Callbacking cb) 
{
	return 0;
}