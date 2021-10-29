using DanielsPasswords.Database;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DanielsPasswords
{
    public class Program
    {
        static void Main()
        {
            while (true) Run();
        }

        public static int Run()
        {
            Console.Clear();
            Console.Write("[1] Login\n[2] Sign Up\n\n\n> ");
            string input = Console.ReadLine();
            Console.Clear();

            if (!int.TryParse(input, out int choice)) return FinalMessage("Invalid input...", 404);
            else if (choice > 2 && choice < 1) return FinalMessage("Invalid input...", 404);

            return choice switch
            {
                1 => OnLogin(),
                2 => OnSignUp(),
                _ => 404,
            };
        }

        private static int FinalMessage(string message, int code = 200)
        {
            Console.WriteLine(message);
            Thread.Sleep(2500);
            return code;
        }
        public static int OnLogin() => OnLogin(GetLoginDetails());
        public static int OnLogin(Login login, bool allowLogout = true)
        {
            bool loggedIn = Login.TryLogin(login);
            if (!loggedIn) return FinalMessage("Invalid username or password...", 404);
            if (!allowLogout) return 200;

            Console.WriteLine($"Welcome back, {login.Username!}\n\nClick any key  to log out");
            Console.ReadKey();
            return 200;
        }
        public static int OnSignUp() => OnSignUp(GetLoginDetails());
        public static int OnSignUp(Login login, bool allowLogout = true)
        {
            Login existing = Login.FindMatch($"Username = {SQLSaver.ResolveInjection(login.Username)}");
            if (existing != null) return Login.Hash(login.Username, login.Password) == existing.Password ? OnLogin(login, allowLogout) : 404;

            try { Login.AddLogin(login.Username, login.Password); }
            catch (Exception e) { return FinalMessage(e.Message, 404); }
            return FinalMessage($"Welcome, {login.Username}!");
        }
        private static Login GetLoginDetails()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Clear();
            return new Login(username, password);
        }
    }
}
