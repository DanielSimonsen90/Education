using System;
using System.Collections.Generic;
using DanhoLibrary;

namespace Rap_Finands 
{
    class Konto
    {
        public Konto(string RegiNumber) 
        {
            Transactions = new List<Transaktion>();
            RegiNum = RegiNumber;
            CardNumber = CreateCardNumber();
        }

        public string RegiNum, CardNumber, Holder;
        public List<Transaktion> Transactions;

        /// <summary>
        /// Creates random CardNumber
        /// </summary>
        /// <returns><see cref="CardNumber"/></returns>
        private string CreateCardNumber()
        {
            string nr = new Random().Next(9).ToString();
            for (var i = 1; i <= 16; i++)
            {
                nr += new Random().Next(9).ToString();
                if (i == 3 || i == 7 || i == 11)
                    nr += " ";
            }
            return nr;
        }
        /// <summary>
        /// Returns the amount of money on <see cref="Konto"/>
        /// </summary>
        /// <returns>Amount of money on account</returns>
        public float OnAccount()
        {
            return (Transactions.Count > 0) ? Transactions[Transactions.Count - 1].OnAccount : 0;
        }

        /// <summary>
        /// Runs User through <see cref="Konto"/> creation
        /// </summary>
        /// <returns>New Konto</returns>
        public static Konto CreateKonto(string RegiNumber, List<Konto> Konti)
        {
            //Create Konto
            Console.Write("Fulde navn på kontoejer: ");
            Konto NewKonto = new Konto(RegiNumber)
            {
                Holder = Console.ReadLine()
            };

            Console.WriteLine();
            Console.Write("Konto oprettet!");
            Konti.Add(NewKonto);
            ConsoleItems.Wait(3000);
            Console.Clear();
            return NewKonto;
        }
        /// <summary>
        /// Lists all Konto, and makes User choose one of displayed
        /// </summary>
        /// <returns>Konto that user was looking for</returns>
        public static Konto FindKonto(List<Konto> Konti)
        {
            for (var i = 1; i <= Konti.Count; i++)
                Console.WriteLine($"{i}. {Konti[i - 1].Holder}: {Konti[i - 1].CardNumber}, {Konti[i - 1].RegiNum}");

            Console.WriteLine();
            Console.WriteLine($"Vælg et tal fra 1-{Konti.Count}");
            Console.Write("> ");
            int tal = int.Parse(Console.ReadLine());
            if (tal < 1 || tal > Konti.Count)
            {
                Console.WriteLine("Ugyldigt valg");
                ConsoleItems.Wait(3000);
                Console.Clear();
                return null;
            }
            Console.Clear();
            return Konti[tal - 1];
        }
        /// <summary>
        /// Prints all <see cref="Konto"/> in <see cref="Program.Konti"/>
        /// </summary>
        public static void PrintKonti(List<Konto> Konti)
        {
            Console.WriteLine("================");
            foreach (Konto Konto in Konti)
                Console.WriteLine($"{Konto.Holder}: {Konto.RegiNum} {Konto.CardNumber}");
        }
        /// <summary>
        /// Prints specified <paramref name="Konto"/>
        /// </summary>
        /// <param name="Konto">Konto to print</param>
        public static void PrintKonto(Konto Konto)
        {
            ConsoleItems.Title($"Konto for {Konto.Holder}: {Konto.RegiNum} {Konto.CardNumber}");
            Console.WriteLine("{0, -30} {1, -15} {2, -15}", "Tekst", "Beløb", "Saldo");

            foreach (Transaktion Transaction in Konto.Transactions)
                Console.WriteLine("{0, -30} {1, -15} {2, -15}", Transaction.Text, Transaction.Amount, Transaction.OnAccount);
        }
    }
}