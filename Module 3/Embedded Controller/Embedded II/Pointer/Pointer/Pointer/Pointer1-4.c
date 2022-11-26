/*
* Pointer.c
*
* Created: 5/31/2021 11:14:06 AM
* Author : dani146d
*/

#include <avr/io.h>
#include "UART.h"

void clear()
{
	for (int i = 0; i < 20; i++)
	{
		printf("\n");
	}
}

int main(void)
{

	
	RS232Init();    // Init UART
	clear();		// Clear hercules log
	
	opgave4();

	while (1);
}

void opgave1()
{
	/*
	&i_ptr: i_ptr's addresse
	i_ptr: Den addresse i_ptr peger på
	*i_ptr: Indeholdet på i_ptr
	*/

	int *i_ptr;		// int pointer
	char *c_ptr;	// char pointer
	int tal = 0XCC33;
	
	i_ptr = &tal;	// Sætter ipointer = adressen på tal | 0xCC33
	c_ptr = i_ptr;	// c_ptr peger nu på samme adr som i_ptr. | 0xCC33
	
	// Udskriver informationer omkring i_prt.
	//printf("i_ptr adr=%x, adr i_ptr peger på=%x, indhold af det i_ptr peger på=%x\n\n", &i_ptr, i_ptr, *i_ptr, );
	
	printf("\nint *i_ptr\n\tAddresse: %x, \n\tAddressen der bliver peget på: %x, \n\tIndholdet af addressen der bliver peget på: %x \n\n", &i_ptr, i_ptr, *i_ptr);
	printf("\nchar *c_ptr\n\tAddresse: %x, \n\tAddressen der bliver peget på: %x, \n\tIndholdet af addressen der bliver peget på: %x \n\n", &c_ptr, c_ptr, *c_ptr);
}

int Plus(int tal1, int tal2)
{
	// Bytter om på de to variabler (Kopierne)
	int tmp = tal1;
	tal1 = tal2;
	tal2 = tmp;
	
	tmp = tal1 + tal2;
	
	return tmp;
}
int ptrPlus(int *tal1, int *tal2)
{
	// Bytter om på de to variabler der peges til (Originalerne!)
	int tmp = *tal1;
	*tal1 = *tal2;
	*tal2 = tmp;
	
	tmp = *tal1 + *tal2;
	
	return tmp;
}
void opgave2()
{
	int tal1 = 17;
	int tal2 = 25;
	int resultat = 0;
	
	
	// Kalder Plus funktionen og kopierer automatisk de to variabler over på stakken.
	resultat = Plus(tal1, tal2);
	
	// viser at tal1 og tal2 stadig er de samme;
	printf("tal 1 = %d, tal2 = %d. Resultatet af Plus = %d\n", tal1, tal2, resultat);
	
	// Kalder pPlus funktionen og kopierer automatisk adresserne på de to variabler
	// over på stakken.
	resultat = ptrPlus(&tal1, &tal2);
	
	// viser at tal1 og tal2 blev modificeret i ptrPlus funktionen.
	printf("tal 1 = %d, tal2 = %d. Resultatet af pPlus = %d\n", tal1, tal2, resultat);
}

struct Point3D
{
	int X;
	int Y;
	int Z;
};
void doStuff(struct Point3D punkt)
{
	// Dette er en lokal kopi, så vores ændringer gælder kun herinde...
	printf("Ændrer i den lokale kopi\n");
	punkt.X--;
	punkt.Y++;
	punkt.Z++;
}
void ptrDoStuff(struct Point3D *punkt)
{
	printf("Ændrer i den originale variabel\n");
	punkt->X++;
	punkt->Y++;
	punkt->Z++;
};
opgave3()
{
	// Opretter en variabel af typen Point3D
	struct Point3D punkt1;

	// Tilskriver de enkelte variabler en af gangen.
	punkt1.X = 10;
	punkt1.Y = 2;
	punkt1.Z = 0;
	
	// her er et eksempel på hvordan du også kan oprette
	// og tilskrive en struct med det samme
	// struct Point3D newPoint = {20, 7, 10};
	// Rækkefølgen er            X, Y,  Z  -> Altså som de er listet i structen.
	
	//udskriver værdier inden vi kalder doStuff
	printf("X = %d, Y = %d, Z = %d\n\n",punkt1.X, punkt1.Y, punkt1.Z);

	//Overfører en lokal kopi af en point3D
	doStuff(punkt1);
	
	//udskriver værdier efter vi har kaldt doStuff
	printf("doStuff:\nX = %d, Y = %d, Z = %d\n\n",punkt1.X, punkt1.Y, punkt1.Z);

	ptrDoStuff(&punkt1);
	printf("ptrDoStuff:\nX = %d, Y = %d, Z = %d\n\n",punkt1.X, punkt1.Y, punkt1.Z);
	
}

opgave4()
{
	char cData[] = {"Pointers are easy as"};
	char *pcData = NULL;

	int iData[] = {1,2,3};
	int *piData = NULL;
	
	printf("cData har %d bytesize elementer\n", sizeof(cData));
	printf("iData har %d bytesize elementer\n", sizeof(iData));
	
	//cData uden [] indeholder adressen på første element i arrayet.
	pcData = cData;
	
	//Forløkke ud fra størrelsen på char cData
	for(int i = 0; i < sizeof(cData); i++)
	{
		printf("&cData[%d] = 0x%x, cData[%d] = %c\n", i, &cData[i],  i, *pcData++);
	}

	// pointer til test af int arrayet
	int *ip = iData;

	//forløkke, af int array
	for(int i = 0; i < sizeof(iData) / sizeof(int); i++)
	{
		piData = &iData[i];
		printf("&iData[%d] = 0x%x, iData[%d] = %d\n", i, piData,  i, *ip++);
	}
}

void PrintSize(int aTest[])
{
	printf("aTest er %d bytes stort", sizeof(aTest));
}

opgave5()
{
    char cData[] = "Pointers aren't always cool!";
    
    PrintSize(cData);

}