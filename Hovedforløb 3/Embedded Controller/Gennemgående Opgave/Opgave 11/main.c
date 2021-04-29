/*
 * Opgave 11.c
 *
 * Created: 4/29/2021 1:18:26 PM
 * Author : dani146d
 */ 

#include <avr/io.h>


unsigned char cmd USART_receive() {
	/* replace with your code */
	return cmd;
}

void USART_transmit(unsigned char cmd) {
	/* replace with your code */
}

void USART_Init () {
	/* replace with your code */
}
int main(void)
{
	USART_Init();
	
	while (1)
	{
		USART_transmit(USART_receive());
	}
}


