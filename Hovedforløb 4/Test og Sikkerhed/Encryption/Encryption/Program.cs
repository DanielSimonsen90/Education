using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

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
            /* 
             * Commandline friendly - use e <key> ...message instead of typing the whole encrypt word 
             * 
             * > e 12 This is a test message
             */
            Console.WriteLine(
                "[E]ncrypt <key> ...message\n" +
                "[D]ecrypt <key> ...message\n" +
                "[F]ind ...message\n"
            );
            Console.Write("Command: ");
            //Get a list of arguments - each " " is an argument
            List<string> args = Console.ReadLine().ToUpper().Split(" ").ToList();
            Console.Clear();

            //Get command (E/D/F) and remove it from args
            string command = args[0];
            args.Remove(command);

            //Get the command result
            string result = GetResult(command, args);
            if (result == string.Empty) return;

            Console.WriteLine(result);
            Console.ReadKey();
        }

        /// <summary>
        /// Returns wanted result from <paramref name="command"/>
        /// </summary>
        /// <param name="command">Command requested</param>
        /// <param name="args">Arguments for command</param>
        /// <returns></returns>
        static string GetResult(string command, List<string> args)
        {
            //[E]ncrypt || [D]ecrypt called
            if (command.StartsWith("E") || command.StartsWith("D")) return OnEncryptDecrypt(command, args);
            //[F]ind called
            else if (command.StartsWith("F")) return OnFind(args);
            //Unknown command
            else return string.Empty;
        }
        /// <summary>
        /// Handles encryption/decryption
        /// </summary>
        /// <param name="command">Encrypt || Decrypt</param>
        /// <param name="args">Arguments for encryption/decryption</param>
        /// <returns></returns>
        static string OnEncryptDecrypt(string command, List<string> args)
        {
            //Get the key(s) for encryption/decryption
            string keys = args[0];
            args.Remove(keys);

            //If true, encryption method is Ceasar, else Vigenere
            bool isInt = int.TryParse(keys, out int key);

            //Message to encrypt/decrypt - Join the rest of the args list with " ", so the whole message is recovered
            string message = new StringBuilder().AppendJoin(" ", args).ToString();

            //Return result of encryption/decryption
            return command.StartsWith("E") ?
                isInt ? Vigenere.Encrypt(message, key) : Vigenere.Encrypt(message, keys) :
                isInt ? Vigenere.Decrypt(message, key) : Vigenere.Decrypt(message, keys);
        }
        /// <summary>
        /// Handles find command. Returns final string with list of possible keys used for encryption
        /// </summary>
        /// <param name="args">Arguments for command</param>
        /// <returns></returns>
        static string OnFind(List<string> args)
        {
            //Message to find the key for - Join the rest of the args list with " ", so the whole message is recovered
            string message = new StringBuilder().AppendJoin(" ", args).ToString();
            //List of possible keys and their values. Dictionary<Key possibility, message with key>
            var keys = Vigenere.FindKey(message).ToList();
            
            StringBuilder sb = new();
            
            //Append all possibilities in 1 string
            foreach (var kvp in keys)
                sb.Append($"{kvp.Key}: {kvp.Value}\n\n");

            return sb.ToString();
        }
    }
}

