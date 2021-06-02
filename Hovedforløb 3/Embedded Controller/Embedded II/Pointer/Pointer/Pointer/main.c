/*
* Pointer.c
*
* Created: 5/31/2021 11:14:06 AM
* Author : dani146d
*/

#include <avr/io.h>
#include "UART.h"

void clear() 
{
	for (int i = 0; i < 20; i++)
	{
		printf("\n");
	}
}

int main(void)
{

	
	RS232Init();    // Init UART
	clear();		// Clear hercules log
	
	opgave2();

	while (1);
}

void opgave1() 
{
	/*
		&i_ptr: i_ptr's addresse
		i_ptr: Den addresse i_ptr peger på
		*i_ptr: Indeholdet på i_ptr
	*/

	int *i_ptr;		// int pointer
	char *c_ptr;	// char pointer
	int tal = 0XCC33;
	
	i_ptr = &tal;	// Sætter ipointer = adressen på tal | 0xCC33
	c_ptr = i_ptr;	// c_ptr peger nu på samme adr som i_ptr. | 0xCC33
	
	// Udskriver informationer omkring i_prt.
	//printf("i_ptr adr=%x, adr i_ptr peger på=%x, indhold af det i_ptr peger på=%x\n\n", &i_ptr, i_ptr, *i_ptr, );
	
	printf("\nint *i_ptr\n\tAddresse: %x, \n\tAddressen der bliver peget på: %x, \n\tIndholdet af addressen der bliver peget på: %x \n\n", &i_ptr, i_ptr, *i_ptr);
	printf("\nchar *c_ptr\n\tAddresse: %x, \n\tAddressen der bliver peget på: %x, \n\tIndholdet af addressen der bliver peget på: %x \n\n", &c_ptr, c_ptr, *c_ptr);
}

void opgave2() 
{
	int tal1 = 17;
	int tal2 = 25;
	int resultat = 0;
	
	
	// Kalder Plus funktionen og kopierer automatisk de to variabler over på stakken.
	resultat = Plus(tal1, tal2);	
	
	// viser at tal1 og tal2 stadig er de samme;
	printf("tal 1 = %d, tal2 = %d. Resultatet af Plus = %d\n", tal1, tal2, resultat);
	
	// Kalder pPlus funktionen og kopierer automatisk adresserne på de to variabler                
    // over på stakken.
	resultat = ptrPlus(&tal1, &tal2);		
	
	// viser at tal1 og tal2 blev modificeret i ptrPlus funktionen.
	printf("tal 1 = %d, tal2 = %d. Resultatet af pPlus = %d\n", tal1, tal2, resultat);
}
int Plus(int tal1, int tal2)
{
	// Bytter om på de to variabler (Kopierne)
	int tmp = tal1;
	tal1 = tal2;
	tal2 = tmp;
	
	tmp = tal1 + tal2;
	
	return tmp;
}

int ptrPlus(int *tal1, int *tal2)
{
	// Bytter om på de to variabler der peges til (Originalerne!)
	int tmp = *tal1;
	*tal1 = *tal2;
	*tal2 = tmp;
	
	tmp = *tal1 + *tal2;
	
	return tmp;
}
