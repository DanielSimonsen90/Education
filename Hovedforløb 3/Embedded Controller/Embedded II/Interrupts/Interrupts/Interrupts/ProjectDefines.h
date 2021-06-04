/*
 * ProjectDefines.h
 *
 * Created: 10-05-2020 21:42:59
 *  Author: ltpe
 */ 


#ifndef PROJECTDEFINES_H_
#define PROJECTDEFINES_H_

#if defined (_AVR_IOM168_H_) || defined (_AVR_IOM328P_H_)
#define USR0_Vect_Num USART_RX_vect
#endif

#if defined(_AVR_IOM2560_H_)
#define USR0_Vect_Num USART0_RX_vect
#endif

#define Upper_Lower_Bit_Position 5
#define Upper_Lower_Bit_Value (1 << Upper_Lower_Bit_Position)

#endif /* PROJECTDEFINES_H_ */