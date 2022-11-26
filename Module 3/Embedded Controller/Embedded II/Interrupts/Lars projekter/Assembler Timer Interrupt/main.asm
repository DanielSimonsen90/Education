;
; h3pd040120_Timer0_OverFlow_Interrupt_Asm.asm
;
; Created: 16-05-2020 00:36:28
; Author : ltpe
;


/********************************************************************************************************
 Include filer, der definerer projekt definitioner, erkl�ringer i EEprom (eseg) og erkl�ringer i RAM (desg)
 f�lger herefter. 
*********************************************************************************************************/
	.include "ProjectDefines.inc"
	.include "RAMDefines.inc"
	.include "TimerDefines.inc"

/********************************************************************************************************
 Start p� Kode (cseg). 
*********************************************************************************************************/
	.cseg

/********************************************************************************************************
 Interruptvektorer i cseg. 
*********************************************************************************************************/
	.org		RWW_START_ADDR
	rjmp		main

	.org		OVF0addr  
	jmp			TIMER0_OVERFLOW_INTERRUPT

/********************************************************************************************************
 Start p� Program Kode (cseg). 
*********************************************************************************************************/
	.org		INT_VECTORS_SIZE

	.include	"Macro.asm"
	.include	"Timer.asm"
	

main:
	SetupStack

	ldi			R16, 0xFF                     ; R16 = 0xFF 
	out			DDRB, R16                     ; DDRB = 0xFF
	com			R16                           ; R16 = 0xFF
	out			PORTB, R16                    ; PORTB = R16 = 0x00
	sts			PortBValue, R16               ; S�t variabel i RAM PortBValue = R16 = 0x00 

	ldi			R16, 0x00                     ; R16 = 0x00
	sts			Timer0OverflowCounter, R16    ; S�t variabel i RAM Timer0OverflowCounter = R16 = 0x00

	ldi			R16, Timer0_1SecondInterruptValue     ; R16 = Timer0_1SecondInterruptValue = 122
	sts			Timer0OverflowCounterStopValue, R16   ; S�t variabel i RAM Timer0OverflowCounterStopValue = R16 = 245
	
	rcall		SetupTimer0OverflowInterrupt  ; Kald funktion SetupTimer0OverflowInterrupt
	rcall		EnableTimer0OverflowInterupt  ; Kald funktion EnableTimer0OverflowInterupt

	sei                                       ; Enable for Global Interrupt. Global Interrupt skal
	                                          ; v�re enabled, ellers er der ingen Interrupts 
											  ; overhovedet, der kan aktiveres !!!

loop:
	rjmp		loop                          ; Vent her i en uendelig l�kke. Programmet k�rer
	                                          ; udelukkende p� TimerInterrupt. Funktionen 
											  ; TIMER0_OVERFLOW_INTERRUPT i filen Timer.asm