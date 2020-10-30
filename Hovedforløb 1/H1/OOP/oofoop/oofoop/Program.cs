using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oofoop
{
    class Program
    {
        #region GetInfo
        /// <summary>
        /// Get User info
        /// </summary>
        /// <returns>Human</returns>
        static Human GetInfo()
        {
            Console.Write("What is your naem?!: ");
            string name = Console.ReadLine();
            Console.Write("How much cash do you have on you right now?: ");
            var Cash = (float)Convert.ToDouble(Console.ReadLine());
            var CreditCard = GetCreditCard(name);
            return new Human(name, Cash, CreditCard, GetSmartPhone(CreditCard));
        }
        /// <summary>
        /// Get User's CreditCard
        /// </summary>
        /// <param name="Name">Name of User</param>
        /// <returns>CreditCard</returns>
        static CreditCard GetCreditCard(string Name)
        {
            Console.Write("How much money do you have on your card?: ");
            var OnAccount = (float)Convert.ToDouble(Console.ReadLine());
            return new CreditCard(Name, OnAccount);
        }
        /// <summary>
        /// Gets User's SmartPhone
        /// </summary>
        /// <param name="Card">User's CreditCard</param>
        /// <returns>SmartPhone</returns>
        static SmartPhone GetSmartPhone(CreditCard Card)
        {
            Console.Write("What brand is your SmartPhone?: ");
            var Brand = Console.ReadLine();
            Console.Write("What model is your SmartPhone?: ");
            return new SmartPhone(Brand, Console.ReadLine(), new MobilePay(Card));
        }
        #endregion

        public static void Main()
        {
            var User = GetInfo();
            var VendingMachine = new VendingMachine(new Product[]
            {
                new Product("Mars", 1, 10, 25),
                new Product("Twix", 2, 10, 25),
                new Product("Snicker", 3, 10, 25),
                new Product("Yankie", 4, 10, 25)
            });
            VendingMachine.Main(User);
        }
    }
}
