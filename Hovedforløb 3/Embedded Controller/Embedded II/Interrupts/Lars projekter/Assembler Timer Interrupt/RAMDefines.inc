/*
 * RAMDefines.inc
 *
 *  Created: 01-01-2018 12:48:51
 *   Author: ltpe
 */ 

 /********************************************************************************************************
 Intern Ram definitioner f�lger herefter.
*********************************************************************************************************/
		.dseg
				
		.org	SRAM_START
		
		Timer0OverflowCounter:	.BYTE		1		; Counter til at t�lle antal Timer0 Overf�ow Interrupts
		Timer0OverflowCounterStopValue:.Byte	1	; Stop Counter v�rdi for antal Timer0 Overf�ow Interrupts	
		PortBValue:				.Byte		1       ; Status af PORT B output 
				
/********************************************************************************************************
 Slut p� Intern Ram definitioner. 
*********************************************************************************************************/
