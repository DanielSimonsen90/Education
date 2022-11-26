/*
 * Opgave 5b.c
 *
 * Created: 4/29/2021 12:11:09 PM
 * Author : dani146d
 */ 

#define F_CPU 16000000UL //Set system clock-speed to 16MHz

#include <avr/io.h>
#include <util/delay.h>

#define SPL  _SFR_IO8 (0x3D) //Create variable SPL pointing to _SFR_IO8's 0x3D
#define SPH  _SFR_IO8 (0x3E) //Create variable SPH pointing to _SFR_IO8's 0x3E

#define low(x)   ((x) & 0xFF) //Define low function that turns variable x off
#define high(x)   (((x)>>8) & 0xFF) //Define high function that turns variable x on

void shift_example () {
	PORTB |= (1 << 5); //OR operation: Shift a bit on 5th position on PORTB, if not already on
	/*
	0000 0000
	0001 0000
	*/
	_delay_ms(1000); //Wait 1 second
	PORTB &= ~(1 << 5); //NOT-AND operation: on PORB with a NOT bit shifting on 5th position
	/*
	0001 0000
	1110 1111
	0000 0000
	*/
	_delay_ms(1000); //Wait 1 second
	PORTB ^= (1 << 5); //Exclusive OR (XOR) operation: Same principle as -x * -x = y and -x * x = -y
	/*
	0000 0000
	0001 0000
	1110 1111
	*/
	_delay_ms(1000); //Wait 1 second
	PORTB >>= 2; //Shift the whole byte 2 times to the right
	/*
	1110 1111
	1111 1011
	*/
	_delay_ms(1000); //Wait 1 second
	PORTB <<= 1; //Shift the whole byte 1 time to the left
	/*
	1111 1011
	1111 0111
	*/
	_delay_ms(1000); //Wait 1 second
	PORTB <<= 1; //Shift the whole byte 1 time to the left
	/*
	1111 0111
	1110 1111
	*/
	_delay_ms(1000); //Wait a second
}

int main(void)
{
	SPL = low(RAMEND); //Turn SPL off
	SPH = high(RAMEND); //Turn SPH on
	
	DDRB = 0xFF; //Set DDRB to 1111 1111
	
	while (1)
	{
		shift_example();
	}
}


