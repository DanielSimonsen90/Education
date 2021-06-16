using System;

namespace pewpew
{
    class Program
    {
        static void Main()
        {
            string playername = GetPlayername();
            new Game(playername).Start();
        }

        static string GetPlayername()
        {
            Console.Write("Playername: ");
            string playername = Console.ReadLine();
            Console.Clear();
            return playername;
        }
    }
}
