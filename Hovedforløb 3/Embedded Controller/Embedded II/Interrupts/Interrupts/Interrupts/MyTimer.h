/*
 * MyTimer.h
 *
 * Created: 6/7/2021 1:31:46 PM
 *  Author: dani146d
 */ 

#include "DanielTypes.h"

#ifndef MYTIMER_H_
#define MYTIMER_H_

extern void SetupTimer();
extern void EnableTimer();
extern void DisableTimer();
extern uint8_t ToggleOccured(uint8_t toggle);
extern void HandleCallbackChange(char recievedChar);

extern Callbacking callbacks[3];

#endif /* MYTIMER_H_ */