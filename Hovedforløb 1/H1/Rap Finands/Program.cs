using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Rap_Finands
{
    /**
    Dette BANK PROGRAM ER LAVET af Konrad Sommer! Copy(c) Right All rights reserveret 2020
    idé og udtænkt af Anne Dam for Voldum Bank I/S
    Rap Finands
    **/
    class Program
    {
        #region Global Variables
        static readonly string RegiNumber = "4242";
        static readonly string DataFile = "bank.json"; //Her ligger alt data i
        static List<Konto> Konti;
        #endregion

        #region Data Methods
        /// <summary>
        /// Saves Data of <see cref="Konti"/> in <see cref="DataFile"/>
        /// </summary>
        static void GemData() 
        {
            File.WriteAllText(DataFile, JsonConvert.SerializeObject(Konti));
        }
        /// <summary>
        /// Assigns the values of <see cref="DataFile"/> and <see cref="Konti"/>
        /// </summary>
        static void GetData()
        {
            if (File.Exists(DataFile))
                Konti = JsonConvert.DeserializeObject<List<Konto>>(File.ReadAllText(DataFile));
            
            if (Konti == null)
                Konti = new List<Konto>();
        }
        #endregion

        #region Main Stuff
        static void WelcomeMessage()
        {
            Console.WriteLine("Velkommen til Rap Finans af Konrad Sommer, fuldstændig re-kodet af Daniel Simonsen");
            Console.WriteLine("Hvor skal vi hen i dag?");
            Console.WriteLine();
        }
        static void MainMenu() 
        {
            WelcomeMessage();

            bool Loop = true;
            while (Loop) 
            {
                #region Menu
                Console.WriteLine("1. Opret ny konto");
                Console.WriteLine("2. Hæv/sæt ind");
                Console.WriteLine("3. Se en oversigt");
                Console.WriteLine("0. Afslut");
                Console.WriteLine();
                Console.Write("> ");
                #endregion

                int valg = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (valg) 
                {
                    case 1:
                        Konto.CreateKonto(RegiNumber, Konti);
                        GemData();
                        WelcomeMessage();
                        break;
                    case 2:
                        Transaktion.CreateTransaction(Konto.FindKonto(Konti));
                        GemData();
                        WelcomeMessage();
                        break;
                    case 3:
                        Konto.PrintKonto(Konto.FindKonto(Konti));
                        break;
                    case 0:
                        Loop = false;
                        break;
                    default:
                        Console.WriteLine("UGYLDIGT VALGT!!");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void Main()
        {
            GetData();

            if (Konti.Count == 0) //If Konti is still empty, assign Test Person, Ejvind
            {
                var konto = new Konto(RegiNumber)
                {
                    Holder = "Tester"
                };
                Konti.Add(konto);

                Transaktion.SaveTransaction(konto, "Opsparing", 100);
                Transaktion.SaveTransaction(konto, "Vandt i klasselotteriet", 1000);
                Transaktion.SaveTransaction(konto, "Hævet til Petuniaer", -50);
            }

            MainMenu();
            GemData();
        }
        #endregion
    }
}

