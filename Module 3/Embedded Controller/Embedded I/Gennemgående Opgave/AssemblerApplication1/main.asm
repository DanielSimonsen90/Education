;
; Assignment 3
;
; Created: 4/27/2021 1:58:49 PM
; Author : dani146d
;
.include "m168def.inc" 
.def digitalPin13 = PB5	//Define digitalPin13 as alias for PB5 
ldi r16, 0x20			//set to 5
out DDRB, r16			//send value of r16 to DDRB
out PORTB, r16			//send value of r16 to PORTB

start:
    inc r16
    rjmp start
