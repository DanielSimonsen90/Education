using System;
using DanhoLibrary;
using DBLager.Methods;

namespace DBLager
{
    class Program
    {
        static readonly Database db = new Database();
        static void Main()
        {
            try
            {
                while (true)
                {
                    switch (MainMenu())
                    {
                        case "create":
                            db.Create();
                            Console.ReadKey(true);
                            break;
                        case "update":
                            db.Update();
                            Console.ReadKey(true);
                            break;
                        case "delete":
                            db.Delete();
                            Console.ReadKey(true);
                            break;
                        case "view":
                            db.ViewTable();
                            Console.ReadKey(true);
                            break;
                        default:
                            ConsoleItems.Error("Input not valid");
                            break;
                    }
                    Console.Clear();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Communication failed! Error message:");
                Console.WriteLine(err);
                ConsoleItems.Wait(3000);
            }
        }

        /// <summary>
        /// Main Menu UI
        /// </summary>
        /// <returns>Modifier as string</returns>
        static string MainMenu()
        {
            ConsoleItems.Title("E-Handel", "~ By Simonsen Techs ~");
            Console.WriteLine();
            ConsoleItems.ListOptions(new string[] { "Create", "Update", "Delete", "View Table"}, out int Conversion);
            ConsoleItems.Choice = (Conversion == 1) ? "create" : (Conversion == 2) ? "update" : (Conversion == 3) ? "delete" : (Conversion == 4) ? "view" : "invalid";

            ConsoleItems.Break();
            
            Console.WriteLine("Which database would you like to modify?");
            ConsoleItems.ListOptions(new string[] { "StockItem", "Article", "Location" }, out Conversion);
            db.TableName = (Conversion == 1) ? "STOCKITEM" : (Conversion == 2) ? "ARTICLE" : (Conversion == 3) ? "Location" : "Invalid";
            
            return ConsoleItems.Choice;
        }
    }
}
