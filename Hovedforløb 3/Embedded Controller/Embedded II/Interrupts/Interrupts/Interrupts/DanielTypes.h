/*
 * DanielTypes.c
 *
 * Created: 17-06-2021 09:25:01
 *  Author: dani146d
 */ 

#include <avr/io.h>

typedef uint32_t (*TimerCallback)(uint32_t);

typedef struct
{
	TimerCallback callback;
	uint8_t toggle;
	uint8_t enabled;
	uint32_t result;
} Callbacking;

typedef struct  
{
	char state; //A | R
	char cbItem; //1 | 2 | 3
} HercToggler;