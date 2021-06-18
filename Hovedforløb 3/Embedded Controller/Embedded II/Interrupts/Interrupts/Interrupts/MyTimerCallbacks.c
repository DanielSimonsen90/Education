/*
 * MyTimerCallbacks.c
 *
 * Created: 16-06-2021 13:41:12
 *  Author: dani146d
 */ 

#include "DanielTypes.h"

#define LED PB0 //digitalPin 8

uint32_t TimerCallbackOne(uint32_t counter)
{
	return counter;
}

uint32_t TimerCallbackTwo(uint32_t counter) 
{
	PORTB ^= (1 << LED);
	return LED;
}

uint32_t TimerCallbackThree(uint32_t counter) 
{
	return 0;
}