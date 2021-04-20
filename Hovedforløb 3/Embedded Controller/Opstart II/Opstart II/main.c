#include <avr/io.h>

int main(void)
{
	DDRB |= (1 << DDB5);
    
	while (1) 
    {
		PINB |= (1<<PINB5);
		_delay_ms(1000);
    }
}

