/*
 * Macro.asm
 *
 *  Created: 01-01-2018 12:48:09
 *   Author: ltpe
 */ 

 /********************************************************************************************************
 Macro definitioner følger herefter.
 *********************************************************************************************************/

  /********************************************************************************************************
  Macronavn        : SetupStack
  Beskrivelse      : Sætter Stack Pointer op til øverste adresse i Intern RAM  
  Input            : Ingen
  Output           : Ingen
  Registre anvendt : r16
  Kalder		   : Ingen
 *********************************************************************************************************/
.MACRO SetupStack
	ldi		r16, low(RAMEND)	; Sæt Stakpointer op til at pege på højeste RAM adresse. 
	out		SPL, r16            ; Stakken gror nedad i hukomelsen.
	ldi		r16, high(RAMEND)
	out		SPH, r16
.ENDMACRO