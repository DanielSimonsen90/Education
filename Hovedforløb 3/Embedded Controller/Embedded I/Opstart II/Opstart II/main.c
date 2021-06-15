#define  F_CPU 16000000UL

#include <avr/io.h>
#include <util/delay.h>

#define RED PD0
#define YELLOW PD1
#define GREEN PD2

#define BUTTON PD4
#define TIME 0b01100100 //100

#define ON(color) PORTD |= (1<<color)
#define OFF(color) PORTD &= ~(1<<color)

int main(void)
{
	DDRD |= (1 << DDD0); //Enable pin 0 as output
	DDRD |= (1 << DDD1); //Enable pin 1 as output
	DDRD |= (1 << DDD2); //Enable pin 2 as output
	DDRD &= ~(1 << DDD4); //Enable pin 4 as input
    
	while (1) 
    {
		//If button was pressed
		if (PIND & (1<<BUTTON)) {
			OFF(GREEN);
			ON(YELLOW);
			_delay_ms(7 * TIME);
			OFF(YELLOW);
			OFF(GREEN);
			ON(RED);
			_delay_ms(10 * TIME);
			ON(YELLOW);
			_delay_ms(5 * TIME);
			OFF(RED);
			OFF(YELLOW);
			ON(GREEN);
			_delay_ms(30 * TIME);
		}
		else {
			OFF(RED);
			OFF(YELLOW);
			ON(GREEN);
		}
    }
}

