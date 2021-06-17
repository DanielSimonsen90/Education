/*
 * DanielTypes.c
 *
 * Created: 17-06-2021 09:25:01
 *  Author: dani146d
 */ 

#include <avr/io.h>

typedef uint32_t (*TimerCallback)(Callbacking);

typedef struct
{
	TimerCallback callback;
	uint8_t toggle;
	uint32_t result;
} Callbacking;