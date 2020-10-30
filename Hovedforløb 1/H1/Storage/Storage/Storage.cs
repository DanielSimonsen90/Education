using System;
using System.Collections.Generic;
using System.Linq;
using DanhoLibrary;

namespace Storage
{
    class Storage
    {
        public Item this[int Index] => Products[Index];
        public static List<Item> Products = new List<Item>();
        public bool ProductsStored { get => (Products.Count > 0) ? true : false; }

        #region ViewStorage
        /// <summary>
        /// Goes through Stock.Products either all of 'em or only specified product types
        /// </summary>
        public void ViewStorage()
        {
            ConsoleItems.Title("View Storage");
            Console.WriteLine("Which Items would you like to see?");
            string[] Options = new string[] { "All", "Block", "Tool", "Food" };
            ConsoleItems.ListOptions(Options, out int Conversion);
            ListItems(Options[Conversion - 1]);
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
        }
        /// <summary>
        /// Lists specified items
        /// </summary>
        /// <param name="Type">Type of Items to look for</param>
        private static int[] ListItems(string Type)
        {
            List<int> result = new List<int>();
            Console.Clear();
            Console.WriteLine($"Searching for type: \"{Type}\"");
            Console.WriteLine("{0, -5} {1, -8} {2, -8} {3, -8}", "ID", "Amount", "Type", "Name");
            foreach (Item product in Products)
                if (product.GetType().Name == Type || Type == "All")
                {
                    Console.WriteLine("{0, -5} {1, -8} {2, -8} {3, -8}", product.ID, product.Amount, product.GetType().Name, product.Name);
                    result.Add(product.ID);
                }
            return result.ToArray();
        }
        #endregion

        #region AddItemMenu
        /// <summary>
        /// Adds specified Item to <see cref="Stock"/>
        /// </summary>
        public void AddItem()
        {
            #region Get Type
            int Conversion;
            string[] Options = { "Block", "Tool", "Food" };
            do
            {
                Console.Clear();
                Console.WriteLine("Which item types would you like to add to the storage?");
                ConsoleItems.ListOptions(Options, out Conversion);
            } while (Conversion < 1 || Conversion > 3);

            GetVariables(Options[Conversion - 1], out string Name, out int Amount);
            Item item = new Item("null", 0, Products);

            switch (Conversion)
            {
                case 1:
                    item = new Block(Name, Amount, Products);
                    break;
                case 2:
                    item = new Tool(Name, Amount, Products);
                    break;
                case 3:
                    item = new Food(Name, Amount, Products);
                    break;
            }
            #endregion

            //If product is already in stock, add more to Item.Amount
            foreach (Item Product in Products)
                if (Product.Name == item.Name && Product.ID == item.ID)
                {
                    Product.Amount += item.Amount;
                    Console.Clear();
                    return;
                }

            //If somehow name wasn't set
            if (item.Name == "null")
            {
                ConsoleItems.Error("Something went wrong. Try again.");
                AddItem();
                return;
            }

            Products.Add(item);
            Console.WriteLine();
            Console.WriteLine($"Added {item.Name} to storage.");
            Console.ReadKey(true);
            Console.Clear();
        }

        /// <summary>
        /// Helps <see cref="AddItem"/>
        /// </summary>
        /// <param name="Type">Type of wanted item</param>
        /// <param name="name">Name of Item</param>
        /// <param name="amount">Amount of Items</param>
        private static void GetVariables(string Type, out string name, out int amount)
        {
            Console.Write($"Name of {Type}: ");
            name = Console.ReadLine();
            Console.Write($"Amount of {Type}s: ");

            try { amount = Convert.ToInt32(Console.ReadLine()); }
            catch
            {
                ConsoleItems.Error();
                GetVariables(Type, out name, out amount);
            }
        }
        #endregion

        public void EditItem()
        {
            Item Product = FindItem("Edit"); //Product to edit
            string Part, //Part/Property from Product, User wishes to change 
                PreviousValue, //Previous value of Part
                NewValue = "null"; //New value of Part
            Console.WriteLine();

            #region Get Part
            do
            {
                Console.WriteLine($"What part of {Product.Name} would you like to edit?");
                ConsoleItems.ListOptions(new string[] { "ID", "Name", "Amount" }, out int Conversion);
                Part = (Conversion == 1) ? "ID" : (Conversion == 2) ? "Name" : (Conversion == 3) ? "Amount" : "null";
                if (Part == "null") ConsoleItems.Error("Answer wasn't recognized.");
            } while (Part == "null");
            #endregion

            #region Attempt editing Product
            bool Successful = false;
            do
            {
                PreviousValue = (Part == "Name") ?
                    Product.Name : (Part == "ID") ?
                    Product.ID.ToString() :
                    Product.Amount.ToString();
                Console.WriteLine();
                Console.WriteLine($"What do you want {Product.Name}'s {Part} to be changed to? It is currently {PreviousValue}...");
                try
                {
                    switch (Part)
                    {
                        case "Name":
                            Product.Name = Console.ReadLine();
                            NewValue = Product.Name;
                            break;
                        case "ID":
                            Product.ID = Convert.ToInt32(Console.ReadLine());
                            NewValue = Product.ID.ToString();
                            break;
                        case "Amount":
                            Product.Amount = Convert.ToInt32(Console.ReadLine());
                            NewValue = Product.Amount.ToString();
                            break;
                    }
                    Successful = true;
                }
                catch { ConsoleItems.Error("Invalid input"); }
            } while (!Successful);
            #endregion

            //Write Conclusion message
            if (Part == "Name")
                Console.WriteLine($"Successfully changed {Part} of \"{PreviousValue}\" to {NewValue}.");
            else
                Console.WriteLine($"Successfully changed {Product.Name}'s {Part} from {PreviousValue} to {NewValue}.");
            Console.ReadKey(true);
            Console.Clear();

            if (Product.Amount <= 0)
                RemoveItem(Product);
        }

        #region RemoveItemMenu
        public void RemoveItem()
        {
            Item Product = FindItem("Remove");
            RemoveItem(Product);

            Console.WriteLine();
            Console.WriteLine($"{Product.Name} was removed.");
            Console.ReadKey(true);
            Console.Clear();
        }
        private void RemoveItem(Item Product)
        {
            for (int x = Products.IndexOf(Product); x < Products.Count; x++)
                Products[x].ID -= 1;
            Products.Remove(Product);
        }
        /// <summary>
        /// Gets the type of all Items in Stock.Products and returns Items' types in string[]
        /// </summary>
        /// <returns>Items' types in string[]</returns>
        private static string[] GetStockTypes()
        {
            List<string> result = new List<string>();
            foreach (Item product in Products)
                if (!result.Contains(product.GetType().Name))
                    result.Add(product.GetType().Name);
            return result.ToArray();
        }
        #endregion

        /// <summary>
        /// Goes through process of making user specify the product, and finally returns that product
        /// </summary>
        /// <param name="EditOrRemove">Used in asking the user whether to edit or remove the product, as this is used in <see cref="RemoveItem"/> and <seealso cref="EditItem"/></param>
        /// <returns>Product user was looking for</returns>
        private static Item FindItem(string EditOrRemove)
        {
            if (Products.Count == 0)
                throw new Exception("No products in Storage");
            Console.WriteLine();

            #region Item.GetType()
            Console.WriteLine($"What item would you like to {EditOrRemove}?");
            string[] Options = GetStockTypes();
            ConsoleItems.ListOptions(Options, out int Conversion);
            string WantedProduct = Options[Conversion - 1];
            Console.Clear();
            #endregion

            #region Find Item.ID
            Console.WriteLine($"Which of the following IDs would you like to {EditOrRemove}?");
            int[] IDs = ListItems(WantedProduct);
            ConsoleItems.Choice = Console.ReadLine();
            try 
            { 
                ConsoleItems.ChoiceInt = int.Parse(ConsoleItems.Choice);
                foreach (Item product in Products)
                    if (product.ID == ConsoleItems.ChoiceInt && IDs.Contains(product.ID))
                        return product;
            }
            catch
            {
                foreach (Item product in Products)
                    if (product.GetType().Name == WantedProduct && product.Name == ConsoleItems.Choice)
                        return product;
            }
            return null;
            #endregion
        }
    }
}
