using DanhoLibrary;
using System;

namespace oofoop
{
    class VendingMachine
    {
        public VendingMachine(Product[] Stock)
        {
            this.Stock = Stock;
        }
        /// <summary>
        /// Products in machine
        /// </summary>
        private Product[] Stock { get; set; }
        /// <summary>
        /// Lists all available products in machine
        /// </summary>
        private void ListStock()
        {
            foreach (Product product in Stock)
                if (product.OnStock)
                    Console.WriteLine($"{product.ID}: {product.Name}");
                else
                    Console.WriteLine($"Order status: {product.OrderMore(10)}");
        }
        /// <summary>
        /// Main program of <see cref="VendingMachine"/>
        /// </summary>
        public void Main(Human Customer)
        {
            Product product = new Product("null", -1, 0, 0);

            //Define Product
            do
            {
                ConsoleItems.Title("Vending Machine - By Simonsen Techs");
                ListStock();
                ConsoleItems.Choice = Console.ReadLine();
                Console.Clear();

                try
                {
                    product = FindProduct(ConsoleItems.Choice);
                    ConsoleItems.Loop = (product.Name != "null") ? false : true;
                }
                catch
                {
                    ConsoleItems.Loop = true;
                }
            } while (ConsoleItems.Loop);

            Console.Clear();

            if (BuyProduct(GetPaymentMethod(product, out float price), price, product, Customer))
                Console.WriteLine($"Thank you for your purchase! Enjoy your {product.Name}!");
            else
                Console.WriteLine("Payment failed! Deal cancelled.");
        }

        /// <summary>
        /// Find the product user is asking for
        /// </summary>
        /// <param name="Choice">Request from user</param>
        /// <returns></returns>
        private Product FindProduct(string Choice)
        {
            try
            {
                foreach (Product product in Stock)
                    if (Convert.ToInt32(Choice) == product.ID)
                        return product;
            }
            catch
            {
                foreach (Product product in Stock)
                    if (Choice.ToLower() == product.Name.ToLower())
                        return product;
            }
            ConsoleItems.Error(Choice);
            return null;
        }
        /// <summary>
        /// Gets Payment method & price
        /// </summary>
        /// <param name="product">Product to buy</param>
        /// <param name="price">Final price of amount of products bought</param>
        /// <returns>[EXPECTED]: "cash" || "card" || "mobilepay"</returns>
        private string GetPaymentMethod(Product product, out float price)
        {
            ConsoleItems.Title("Payment Method");
            if (product.WantedQuantity > 1)
                Console.WriteLine($"Please insert your payment method to pay for {product.WantedQuantity} {product.Name}s");
            else
                Console.WriteLine($"Please insert your payment method to pay for {product.WantedQuantity} {product.Name}");
            Console.WriteLine($"Price: {price = product.CalculatePrice()}");

            Console.WriteLine();

            ConsoleItems.ListOptions(new string[] { "Cash", "Card", "MobilePay" });
            ConsoleItems.Choice = Console.ReadLine().ToLower();
            Console.Clear();
            if (ConsoleItems.Choice != "cash" ||
                ConsoleItems.Choice != "card" ||
                ConsoleItems.Choice != "mobilepay")
                return "failed";
            return ConsoleItems.Choice;
        }
        /// <summary>
        /// Validchecks <see cref="GetPaymentMethod(Product, out float)"/> - redirects to PaymentMethod methods
        /// </summary>
        /// <param name="PaymentMethod"><see cref="GetPaymentMethod(Product, out float)"/>, <paramref name="Customer"/>'s preferred payment method</param>
        /// <param name="Price">Final price of <paramref name="product"/>"/></param>
        /// <param name="product">Product the <paramref name="Customer"/> wishes to buy</param>
        /// <param name="Customer">Human who is using the machine</param>
        /// <returns>If purchase was successful</returns>
        private bool BuyProduct(string PaymentMethod, float Price, Product product, Human Customer)
        {
            string ReturnedText;
            switch (PaymentMethod)
            {
                case "cash":
                    if (CashMethod(Customer, Price, product, out ReturnedText))
                    {
                        Console.WriteLine(ReturnedText);
                        return true;
                    }
                    Console.WriteLine(ReturnedText);
                    return false;
                case "card":
                    if (CardMethod(Customer, Price, product, out ReturnedText))
                    {
                        Console.WriteLine(ReturnedText);
                        return true;
                    }
                    Console.WriteLine(ReturnedText);
                    return false;
                case "mobilepay":
                    if (MobilePayMethod(Customer, Price, product, out ReturnedText))
                    {
                        Console.WriteLine(ReturnedText);
                        return true;
                    }
                    Console.WriteLine(ReturnedText);
                    return false;
                default:
                    Console.Write("Payment method not recognized! Please try again");
                    ConsoleItems.Wait(3000);
                    Console.Clear();
                    return BuyProduct(GetPaymentMethod(product, out float price), price, product, Customer);
            }
        }

        /// <summary>
        /// <paramref name="Customer"/> pays with cash
        /// </summary>
        /// <param name="Customer">Customer using machine</param>
        /// <param name="Price">Total price of specified <paramref name="product"/>(s)</param>
        /// <param name="product">Product the <paramref name="Customer"/> is buying</param>
        /// <param name="ReturnedText">ErrorMessage, "Thank you!"</param>
        /// <returns></returns>
        private bool CashMethod(Human Customer, float Price, Product product, out string ReturnedText)
        {
            #region Is purchase possible?
            //If enough cash
            ReturnedText = "You do not have enough cash on you.";
            if (Customer.Cash < Price)
                return false;
            //If machine has enough on stock
            if (product.InMachine < product.WantedQuantity)
            {
                ReturnedText = $"Machine cannot provide {product.WantedQuantity} {product.Name}!";
                Console.WriteLine($"Product Delivery Message: {product.OrderMore(10)}");
                return false;
            }
            #endregion

            Customer.Cash -= Price;
            product.InMachine -= product.WantedQuantity;
            ReturnedText = $"Thank you for purchasing {product.WantedQuantity} {product.Name}!";
            if (product.InMachine < 10)
                product.OrderMore(10);
            product.WantedQuantity = 0;
            return true;
        }
        /// <summary>
        /// Customer pays with card
        /// </summary>
        /// <param name="Customer">Customer using machine</param>
        /// <param name="Price">Total price of specified <paramref name="product"/>(s)</param>
        /// <param name="product">Product the <paramref name="Customer"/> is buying</param>
        /// <param name="ReturnedText">ErrorMessage, "Thank you!"</param>
        /// <returns></returns>
        private bool CardMethod(Human Customer, float Price, Product product, out string ReturnedText)
        {
            #region Is purchase possible?
            ReturnedText = "You do not have enough cash on you.";
            if (Customer.Card.OnAccount < Price)
                return false;
            if (product.InMachine < product.WantedQuantity)
            {
                ReturnedText = $"Machine cannot provide {product.WantedQuantity} {product.Name}!";
                Console.WriteLine($"Product Delivery Message: {product.OrderMore(10)}");
                return false;
            }
            #endregion

            Customer.Card.OnAccount -= Price;
            product.InMachine -= product.WantedQuantity;
            ReturnedText = $"Thank you for purchasing {product.WantedQuantity} {product.Name}!";
            if (product.InMachine < 10)
                product.OrderMore(10);
            product.WantedQuantity = 0;
            return true;
        }
        /// <summary>
        /// Customer pays with MobilePay
        /// </summary>
        /// <param name="Customer">Customer using machine</param>
        /// <param name="Price">Total price of specified <paramref name="product"/>(s)</param>
        /// <param name="product">Product the <paramref name="Customer"/> is buying</param>
        /// <param name="ReturnedText">ErrorMessage, "Thank you!"</param>
        /// <returns></returns>
        private bool MobilePayMethod(Human Customer, float Price, Product product, out string ReturnedText)
        {
            #region Is purchase possible?
            ReturnedText = "You do not have enough cash on you.";
            if (Customer.Card.OnAccount < Price)
                return false;
            if (product.InMachine < product.WantedQuantity)
            {
                ReturnedText = $"Machine cannot provide {product.WantedQuantity} {product.Name}!";
                Console.WriteLine($"Product Delivery Message: {product.OrderMore(10)}");
                return false;
            }
            #endregion
            ReturnedText = Customer.Phone.UseMobilePay(Price);
            if (ReturnedText != "successful")
                return false;
            ReturnedText = $"Thank you for purchasing {product.WantedQuantity} {product.Name}!";
            product.InMachine -= product.WantedQuantity;
            product.WantedQuantity = 0;
            if (product.InMachine < 10)
                product.OrderMore(10);
            return true;
        }
    }
}
