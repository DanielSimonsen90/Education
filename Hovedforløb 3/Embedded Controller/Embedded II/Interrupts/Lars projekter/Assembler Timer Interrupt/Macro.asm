/*
 * Macro.asm
 *
 *  Created: 01-01-2018 12:48:09
 *   Author: ltpe
 */ 

 /********************************************************************************************************
 Macro definitioner f�lger herefter.
 *********************************************************************************************************/

  /********************************************************************************************************
  Macronavn        : SetupStack
  Beskrivelse      : S�tter Stack Pointer op til �verste adresse i Intern RAM  
  Input            : Ingen
  Output           : Ingen
  Registre anvendt : r16
  Kalder		   : Ingen
 *********************************************************************************************************/
.MACRO SetupStack
	ldi		r16, low(RAMEND)	; S�t Stakpointer op til at pege p� h�jeste RAM adresse. 
	out		SPL, r16            ; Stakken gror nedad i hukomelsen.
	ldi		r16, high(RAMEND)
	out		SPH, r16
.ENDMACRO