/*
 * MyTimerCallbacks.c
 *
 * Created: 16-06-2021 13:41:12
 *  Author: dani146d
 */ 

void TimerCallbackOne(int counter)
{
	printf("We have reached the glorious number, %d\n", counter);
}
void TimerCallbackTwo(int counter) 
{
	if (counter == 18)
		printf("And in my opinion, that is a very nice number!\n");
}
void TimerCallbackThree(int counter) 
{
	if (counter == 69)
		printf("This is truly a *click* noice number\n");
}