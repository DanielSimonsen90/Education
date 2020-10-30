using System;
using System.Threading;

namespace TheHungryPhilosophers
{
    class Program
    {
        private static Fork[] Forks;
        private static Philosopher[] GetPhilosophers()
        {
            Forks = new Fork[5];
            Philosopher[] philosophers = new Philosopher[5];
            string[] names = { "Danho", "Kippy", "Shankxs", "Fuchy", "Crimosnic" };

            for (int x = 0; x < Forks.Length; x++)
                Forks[x] = new Fork();
            for (int x = 0; x < philosophers.Length; x++)
                try { philosophers[x] = new Philosopher(names[x], Forks[x], Forks[x + 1]); }
                catch (IndexOutOfRangeException) { philosophers[x] = new Philosopher(names[x], Forks[x], Forks[0]); }

            return philosophers;
        }

        static void Main()
        {
            var Phils = GetPhilosophers();
            Phils.StartThreads(50);
            bool Loop = true;
            while (Loop)
            {
                foreach (Philosopher p in Phils)
                    Console.WriteLine(p);
                Console.WriteLine();
                for (int x = 0; x < Forks.Length; x++)
                    Console.WriteLine($"Fork{x}: {Forks[x].OccupiedByName}");

                Thread.Sleep(500);
                Console.Clear();
            }
        }
    }
    static class IDoTooMuchWork
    {
        public static void StartThreads(this Philosopher[] philosophers, int StartTime)
        {
            foreach (var p in philosophers)
            {
                p.Thread.Start();
                Thread.Sleep(StartTime);
            }
        }
    }
}
