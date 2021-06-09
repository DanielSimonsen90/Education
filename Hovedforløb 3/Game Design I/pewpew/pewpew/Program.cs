using System;

namespace pewpew
{
    class Program
    {
        static void Main()
        {
            Game();
        }

        static void Game()
        {
            
            var game = new Game("Danho");
            game.Start();
        }
        static void Test()
        {
            Console.WriteLine("{0}:{1}", Console.WindowWidth, Console.WindowHeight);
            Console.SetCursorPosition(0, 0);
            Console.Write("0/0");
            Console.SetCursorPosition(0, Console.WindowHeight);
            Console.Write("0/Height");
            Console.SetCursorPosition(Console.WindowWidth - 1, 0);
            Console.Write("Width/0");
            Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight);
            Console.Write("Width/Height");

            Console.ReadKey();
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
