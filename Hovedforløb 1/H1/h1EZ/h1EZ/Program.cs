using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace h1EZ
{
    class Program
    {
        #region Day 1
        //Helpers
        static bool AskTrueFalse(string Question)
        {
            Console.WriteLine(Question);
            return (Console.ReadLine().ToLower() == "yes") ? true : false;
        }

        //Main methods
        static string Login()
        {
            List<string> LoginUsers = new List<string> { "a", "jespapa", "noodle" },
                LoginPasswords = new List<string> { "a", "gedemonster123", "awoogaawooga" };
            string username, password;

            Console.Write("Giv mig navn pls: ");
            username = Console.ReadLine().ToLower();
            Console.Write("Kode ogs yes?: ");
            password = Console.ReadLine().ToLower();

            if (LoginUsers.Contains(username) && LoginPasswords.Contains(password) && LoginPasswords[LoginUsers.IndexOf(username)].Equals(password))
                return username;

            Console.WriteLine($"Sorry, \"{username}\", I don't see you in my data :("); 
            Console.ReadKey();
            Console.WriteLine("Now you must byebye!"); 
            Environment.Exit(0);
            return null;
        }
        static int AgeCalculation()
        {
            Console.Write("When were you born? (DD/MM/YYYY): ");
            try
            {
                TimeSpan TimePassed = DateTime.Now - DateTime.Parse(Console.ReadLine());
                double ActualDate = TimePassed.Days / 365.25;
                string Result = (ActualDate > 99) ? ActualDate.ToString().Substring(0, 3) :
                    (ActualDate < 10) ? ActualDate.ToString().Substring(0, 1) :
                    ActualDate.ToString().Substring(0, 2);

                Console.WriteLine($"So that means you must be {Result} years old!");
                return Convert.ToInt32(Result);
            }
            catch
            {
                Console.WriteLine("Date not valid!");
                return 0;
            }
        }

        #region Reaction Game
        static readonly Player P1, Player2;
        static void ReactionTime(int attempt)
        {
            Console.WriteLine($"Attempt {attempt}");

            //Waiting for start
            Console.WriteLine("On your mark... (press enter to start)");
            Console.ReadKey();
            Console.Clear();

            //Player is ready - starting time
            Console.WriteLine("On your mark...");
            Thread.Sleep(new Random().Next(1000, 6000));

            //Game
            Console.WriteLine("O");
            DateTime TimeStarted = DateTime.Now;

            //Define Player
            var PlayerKey = Console.ReadKey().Key;
            string Name = (PlayerKey.Equals(ConsoleKey.Enter)) ? "Player1" : (PlayerKey.Equals(ConsoleKey.Spacebar)) ? "Player2" : "Null";

            if (Name != "Null")
            {
                Player player = (Name == "Player1") ? P1 : Player2;
                var ReactionTime = Convert.ToInt32((DateTime.Now - TimeStarted).TotalMilliseconds);
                Console.Clear();
                Console.WriteLine($"{player.Name} reaction time was {ReactionTime}ms!");
                player.Highscore.Add(ReactionTime);
            }

            Console.WriteLine("You pressed the wrong button!");
            Console.WriteLine("Game has stopped!");
            Console.ReadKey();
        }
        static void ShowGameLeaderboard(Player player)
        {
            Console.Clear();
            List<int> Leaderboard = new List<int>(),
                BestAttempt = player.Highscore;
            Console.WriteLine($"{player.Name}'s Highscores");
            while(BestAttempt.Count > 0)
            {
                var Item = BestAttempt.Min();
                Leaderboard.Add(Item);
                BestAttempt.Remove(Item);
            }
            for (int x = 0; x < Leaderboard.Count; x++)
            {
                if (x > 9)
                    break;
                Console.WriteLine($"Score {x++}: {Leaderboard.ToArray()[x]}");            
            }
            
            Console.ReadKey();
        }
        #endregion

        #endregion

        static void Main()
        {
            #region Welcome User!
            Console.WriteLine($"Welcome {Login()}!");
            Thread.Sleep(3000);
            Console.Clear();
            #endregion

            #region Reaction Game
            int Attempt = 1;
            do
            {
                Console.Clear();
                ReactionTime(Attempt);
                Attempt++;
                Console.ReadKey();
                Console.Clear();

            } while (AskTrueFalse("Do you wish to continue playing?"));

            Console.Clear();

            if (AskTrueFalse("Do you wish to see the leaderboar?"))
            {
                if (AskTrueFalse("Do you wish to see Player1's Highscore?"))
                    ShowGameLeaderboard(P1);
                else
                    ShowGameLeaderboard(Player2);
            }

            Thread.Sleep(3000);
            Console.Clear();

            #endregion

            //Age calculation
            int Age = AgeCalculation();

            Console.ReadKey();
        }

    }
}
