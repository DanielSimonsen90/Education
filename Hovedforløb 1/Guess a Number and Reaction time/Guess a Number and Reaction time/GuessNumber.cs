using DanhoLibrary;
using System;

namespace Guess_a_Number_and_Reaction_time
{
    internal class GuessNumber
    {
        public GuessNumber()
        {
        }
        private int userResponse, Number = ConsoleItems.RandomNumber(100), Attempts;
        public void Run()
        {
            do
            {
                Console.WriteLine($"Guess a number between 0 - 100 | Attempts: {Attempts}");
                userResponse = int.Parse(Console.ReadLine());
                Attempts++;
                Console.Clear();

                GetResult();
            } while (userResponse != Number);
        }

        private bool WinnerScreen()
        {
            Console.WriteLine($"Correct! You used {Attempts} attenpts.");
            ConsoleItems.Wait(3000);
            Console.WriteLine("Would you like to try again?");
            Console.WriteLine();
            ConsoleItems.ListOptions(out int Conversion, "Yes", "No");
            return Conversion == 1;
        }

        private void GetResult()
        {
            if (Number == userResponse)
                if (WinnerScreen())
                    new GuessNumber().Run();
                else return;
            else
            {
                string HighLow = userResponse > Number ? "LOWER" : "HIGHER";
                Console.WriteLine($"The number is {HighLow} than your guess!");
            }
        }
    }
}