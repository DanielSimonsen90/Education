/*
 * Pointer.c
 *
 * Created: 5/31/2021 11:14:06 AM
 * Author : dani146d
 */ 

#include <avr/io.h>
#include "UART.h"



int main(void)
{
   RS232Init();               // Init UART
   
   int *i_ptr;		// int pointer
   char *c_ptr;	// char pointer
   int tal = 0XCC33;
   
   i_ptr = &tal;	// Sætter ipointer = adressen på tal | 0xCC33
   c_ptr = i_ptr;	// c_ptr peger nu på samme adr som i_ptr. | 0xCC33
   
   // Udskriver informationer omkring i_prt.
   printf("i_ptr adr=%x, adr i_ptr peger på=%x, indhold af det i_ptr peger på=%x\n", &i_ptr, i_ptr, *i_ptr);

   while (1);
}

