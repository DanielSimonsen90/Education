using System;
using System.Collections.Generic;
using DanhoLibrary;

namespace Storage
{
    class Program
    {
        static readonly Storage Stock = new Storage();

        static void Main()
        {
            while (true)
            {
                try
                {
                    if (Stock.ProductsStored)
                        switch (MainMenu())
                        {
                            case 1:
                                Stock.ViewStorage();
                                break;
                            case 2:
                                Stock.AddItem();
                                break;
                            case 3:
                                Stock.EditItem();
                                break;
                            case 4:
                                Stock.RemoveItem();
                                break;
                            case 5:
                                Goodbye();
                                break;
                            default:
                                ConsoleItems.Error(ConsoleItems.ChoiceInt);
                                break;
                        }
                    else
                        switch (MainMenu())
                        {
                            case 1:
                                Stock.AddItem();
                                break;
                            case 2:
                                Goodbye();
                                break;
                            default:
                                ConsoleItems.Error(ConsoleItems.ChoiceInt);
                                break;
                        }
                }
                catch (Exception Error)
                {
                    if (Error.Message != "No products in Storage")
                        Console.WriteLine(Error);
                }
            }
        }

        static void Goodbye()
        {
            Console.WriteLine("Come again soon!");
            ConsoleItems.Wait(1500);
            Environment.Exit(0);
        }

        static int MainMenu()
        {
            ConsoleItems.Title("Simonsen Techs Storage", "Welcome to the storage menu!");
            List<string> Options = (Stock.ProductsStored) ?
                new List<string>() { "View Storage", "Add Item", "Edit Item", "Remove Item", "Exit" } :
                new List<string>() { "Add item", "Exit" };
            
            try
            {
                ConsoleItems.ListOptions(Options.ToArray(), out int Conversion);
                Console.Clear();
                return Conversion;
            }
            catch
            {
                ConsoleItems.Error(ConsoleItems.Choice);
                return MainMenu();
            }
        }
    }
}
