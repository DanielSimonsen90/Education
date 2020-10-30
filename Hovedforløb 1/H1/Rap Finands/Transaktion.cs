using System;
using System.Threading;

namespace Rap_Finands 
{
    class Transaktion 
    {
        /// <summary>
        /// Transaction Note
        /// </summary>
        public string Text;
        /// <summary>
        /// Current Saldo left
        /// </summary>
        public float OnAccount;
        /// <summary>
        /// Amount transacted
        /// </summary>
        public float Amount;
        /// <summary>
        /// Latest Transaction
        /// </summary>
        public DateTime Date;

        public static void CreateTransaction(Konto konto)
        {
            Console.WriteLine($"Opretter transaktion for {konto.Holder}.");
            Console.WriteLine($"Beløb på kontoen: {konto.OnAccount()}");
            Console.WriteLine();

            Console.Write("Tekst: ");
            string Text = Console.ReadLine();
            Console.Write("Beløb: ");
            float Amount = float.Parse(Console.ReadLine());

            Console.WriteLine();
            if (SaveTransaction(konto, Text, Amount))
                Console.Write($"Transkationen blev gemt. Ny saldo på kontoen: {konto.OnAccount()}.");
            else
                Console.WriteLine("Transaktionen kunne ikke gemmes (Der var sikkert ikke penge nok på kontoen)");

            Thread.Sleep(3000);
            Console.Clear();
        }
        /// <summary>
        /// Updates <paramref name="konto"/>'s <see cref="Konto.Transactions"/>
        /// </summary>
        /// <param name="konto">Konto to update</param>
        /// <param name="Tekst">Text of Transaction</param>
        /// <param name="Beløb">Amount of transaction</param>
        /// <returns>true if succeessful</returns>
        public static bool SaveTransaction(Konto konto, string Tekst, float Beløb)
        {
            if (konto.OnAccount() + Beløb < 0)  //If valid
                return false;

            var Transaction = new Transaktion
            {
                Text = Tekst,
                Amount = Beløb,
                Date = DateTime.Now
            };
            Transaction.OnAccount = Transaction.Amount + konto.OnAccount();

            konto.Transactions.Add(Transaction); //Adds latest transaction to transaction history
            return true;
        }
        /// <summary>
        /// Updates <see cref="Transaktion.Date"/> of specified <paramref name="Konto"/>
        /// </summary>
        /// <param name="Konto">Konto to update</param>
        /// <returns><see cref="Transaktion.OnAccount"/></returns>
        public static float FindSaldo(Konto Konto)
        {
            Transaktion LatestTransaction = new Transaktion();
            DateTime LatestTransDate = DateTime.MinValue;

            foreach (var Transaction in Konto.Transactions)
                if (Transaction.Date > LatestTransDate)
                {
                    LatestTransDate = Transaction.Date;
                    LatestTransaction = Transaction;
                }
            return LatestTransaction.OnAccount;
        }
    }
}