using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awesomeboi
{
    class Program
    {
        static void Main()
        {
            string tester = "I er awesome", result;
            int number = 0;
            do
            {
                result = Cloud(number);
                number++;
            } while (tester != result);
            number--;
            Console.WriteLine($"{Cloud(number)}\nNummer: {number}");
            Console.Read();
        }

        private static string Cloud(int number) => number * 2 > 15 ? Sky(number % 15 * 2 + 1, "I") : Sky(number % 15 * 2, "Læreren");
        private static string Sky(int number, string str) => Sun(number * 5, str += number % 2 == 1 && number < 22 ? " er ikke " : " er ");
        private static string Sun(int number, string str) => str += (number > 40 && number < 71 || number > 135) ? "awesome" : "rigtigt kloge";
    }
}
