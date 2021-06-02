/*
* Pointer.c
*
* Created: 5/31/2021 11:14:06 AM
* Author : dani146d
*/

#include <avr/io.h>
#include "UART.h"

void clear() {
	for (int i = 0; i < 20; i++)
	{
		printf("\n");
	}
}

int main(void)
{
	/*
	&i_ptr: i_ptr's addresse
	i_ptr: Den addresse i_ptr peger p�
	*i_ptr: Indeholdet p� i_ptr
	*/
	
	RS232Init();               // Init UART
	clear();
	
	int *i_ptr;		// int pointer
	char *c_ptr;	// char pointer
	int tal = 0XCC33;
	
	i_ptr = &tal;	// S�tter ipointer = adressen p� tal | 0xCC33
	c_ptr = i_ptr;	// c_ptr peger nu p� samme adr som i_ptr. | 0xCC33
	
	// Udskriver informationer omkring i_prt.
	//printf("i_ptr adr=%x, adr i_ptr peger p�=%x, indhold af det i_ptr peger p�=%x\n\n", &i_ptr, i_ptr, *i_ptr, );
	
	printf("\nint *i_ptr\n\tAddresse: %x, \n\tAddressen der bliver peget p�: %x, \n\tIndholdet af addressen der bliver peget p�: %x \n\n", &i_ptr, i_ptr, *i_ptr);
	printf("\nchar *c_ptr\n\tAddresse: %x, \n\tAddressen der bliver peget p�: %x, \n\tIndholdet af addressen der bliver peget p�: %x \n\n", &c_ptr, c_ptr, *c_ptr);

	while (1);
}

