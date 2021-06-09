/*
 * Timer.asm
 *
 *  Created: 01-01-2018 11:48:52
 *   Author: ltpe
 */ 


 /********************************************************************************************************
 Kode følger herefter i kodesegment
 *********************************************************************************************************/
		.cseg

/********************************************************************************************************
  Funktionsnavn    : SetupTimer0OverflowInterrupt
  Beskrivelse      : Sætter Timer 0 Overflow interrupt op. 
  Input            : Ingen
  Output           : Ingen
  Registre anvendt : R17
  Kalder           : Ingen
 *********************************************************************************************************/
 SetupTimer0OverflowInterrupt:
		push	r17                             ; Push R17 register til stakken       

		clr		r17                             ; R17 = 0x00
		out		TCCR0A, r17					    ; TCCR0A register = R17 = 0x00 => Brug Timer 0 som Standard op-tæller.

		//Timer counter register
		out		TCNT0, r17				        ; TCNT0 register = R17 = 0x00 => Sæt 0 som Timer Counter start værdi.

		ldi		r17, (1<<CS02)|(1<<CS00)        ; R17 = (1<<CS02)|(1<<CS00) 
		out		TCCR0B, r17					    ; TCCR0B register = R17 = (1<<CS02)|(1<<CS00) => Timer Clock = System Clock/1024 (16Mhz/1024 = 15.625 "timer svingninger"/s)

		ldi		r17, (1<<TOV0)					; R17 = (1<<TOV0) 	
		out		TIFR0, r17					    ; TIFR0 register = R17 = (1<<TOV0) => Clear TOV0 => Clear pending interrupts
		
		pop		r17                             ; Pop R17 register fra stakken

		ret                                     ; Return fra funktion SetupTimer0OverflowInterrupt

/********************************************************************************************************
  Funktionsnavn    : EnableTimer0OverflowInterupt
  Beskrivelse      : Disable Timer 0 Overflow interrupt. 
  Input            : Ingen.
  Output           : Ingen
  Registre anvendt : R17
  Kalder           : Ingen
 *********************************************************************************************************/
EnableTimer0OverflowInterupt:
		push	r17                            ; Push R17 register til stakken

		lds		r17, TIMSK0                    ; R17 = indhold i register TIMSK0
		sbr		r17, (1<<TOIE0)                ; Sæt bit (1<<TOIE0) i R17
		sts		TIMSK0, r17					   ; TIMSK0 register = R17 => Enable TimerCounter0 Overflow Interrupt
	
		pop		r17                            ; Pop R17 register fra stakken
		ret                                    ; Return fra funktion EnableTimer0OverflowInterupt

/********************************************************************************************************
  Funktionsnavn    : DisableTimer0OverflowInterupt
  Beskrivelse      : Disable Timer 0 Overflow interrupt. 
  Input            : Ingen.
  Output           : Ingen
  Registre anvendt : R17
  Kalder           : Ingen
 *********************************************************************************************************/
DisableTimer0OverflowInterupt:
		push	r17                           ; Push R17 register til stakken

		lds		r17, TIMSK0                   ; R17 = indhold i register TIMSK0
		cbr		r17, (1<<TOIE0)               ; Clear bit (1<<TOIE0) i R17
		sts		TIMSK0, r17					  ; TIMSK0 register = R17 => Disable TimerCounter0 Overflow Interrupt

		pop		r17                           ; Pop R17 register fra stakken
		ret                                   ; Return fra funktion DisableTimer0OverflowInterupt


/*********************************************************************************************************
  Interrupt funktions definitioner følger herefter
*********************************************************************************************************/

/********************************************************************************************************
  Funktionsnavn    : TIMER0_OVERFLOW_INTERRUPT
  Anvendelse       : Behandler Timer0 Overflow Interrupt. 
  Input            : Ingen
  Output           : Ingen
  Registre anvendt : R16
					 R17
  Kalder           : TogglePin
*********************************************************************************************************/
 TIMER0_OVERFLOW_INTERRUPT:
		cli										; Global disable interrupt.
		push	r16                             ; Push R16 register til stakken
		push	r17                             ; Push R17 register til stakken

		lds		r16, Timer0OverflowCounter          ; R16 = værdien af variabel i RAM Timer0OverflowCounter  
		lds		r17, Timer0OverflowCounterStopValue ; R17 = værdien af variabel i RAM Timer0OverflowCounterStopValue  

		cp		r16, r17                            ; Sammenlign indhold i R16 med indhold i R17 
		brne	IncrementTimer0OverflowCounter      ; Hvis indhold i R16 er forskellig fra indhold i R17
		                                            ; så hop til label IncrementTimer0OverflowCounter

		clr		r16                                 ; R16 = 0x00
		sts		Timer0OverflowCounter, r16          ; Sæt variabel i RAM Timer0OverflowCounter = R16 = 0x00

		lds		r16, PortBValue                     ; R16 = værdien af variabel i RAM PortBValue  
		
		ldi		r17, RedLedBitValue                 ; R17 = værdien af konstant RedLedBitValue (defineret i ProjectDefines.inc)
		eor		r16, r17                            ; Xor værdien af R16 med værdien af R17 => vend bit på 

		sts		PortBValue, r16                     ; Sæt variabel i RAM PortBValue = R16
		out		PortB, r16		                    ; Sæt PORTB = R16

		jmp		DoneTreatingTimer0_Overflow_Interrupt  ; Hop til label DoneTreatingTimer0_Overflow_Interrupt

IncrementTimer0OverflowCounter:
		inc		r16                                ; R16 = R16 + 1
		sts		Timer0OverflowCounter, r16         ; Sæt variabel i RAM Timer0OverflowCounter = R16

DoneTreatingTimer0_Overflow_Interrupt:
		pop		r17                             ; Pop R17 register fra stakken
		pop		r16                             ; Pop R16 register fra stakken

		sei										; Global enable interrupt. Ikke nødvendig med denne instruktion, da reti  
												; instruktionen også udfører en sei.

		reti                                    ; Return fra funktion TIMER0_OVERFLOW_INTERRUPT

