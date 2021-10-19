using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DanhoLibrary.Extensions;

namespace Encryption
{
    class Program
    {
        static void Main()
        {
            while (true) Run();
        }
        static void Run()
        {
            Console.Clear();
            Console.WriteLine(new string[]
            {
                "[E]ncrypt <key> ...message",
                "[D]ecrypt <key> ...message",
                "[F]ind ...message"
            }.Join("\n"));
            Console.Write("Command: ");
            List<string> args = Console.ReadLine().ToUpper().Split(" ").ToList();
            Console.Clear();

            string command = args.Shift();
            string result = GetResult(command, args);
            if (result == string.Empty) return;

            Console.WriteLine(result);
            Console.ReadKey();
        }

        static string GetResult(string command, List<string> args)
        {
            if (command.StartsWith("E") || command.StartsWith("D")) return OnEncryptDecrypt(command, args);
            else if (command.StartsWith("F")) return OnFind(args);
            else return string.Empty;
        }
        static string OnEncryptDecrypt(string command, List<string> args)
        {
            string keys = args.Shift();
            bool isInt = int.TryParse(keys, out int key);

            string message = args.Join(" ");
            return command.StartsWith("E") ?
                isInt ? Vigenere.Encrypt(message, key) : Vigenere.Encrypt(message, keys) :
                isInt ? Vigenere.Decrypt(message, key) : Vigenere.Decrypt(message, keys);
        }
        static string OnFind(List<string> args) => 
            Vigenere.FindKey(args.Join(" "))
                .ToList()
                .Map(kvp => kvp.Write())
                .Join("\n\n");
    }
}
