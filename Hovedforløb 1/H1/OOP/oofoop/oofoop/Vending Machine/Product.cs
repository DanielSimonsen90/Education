using System;

namespace oofoop
{
    public class Product
    {
        public Product(string Name, int ID, float Price, int InMachine)
        {
            this.Name = Name;
            this.ID = ID;
            this.Price = Price;
            this.InMachine = InMachine;
            OnStock = (InMachine > 0) ? true : false;
        }
        /// <summary>
        /// Name of Product
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ID of Product in <see cref="VendingMachine"/>
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Price of Product
        /// </summary>
        public float Price { get; set; }
        /// <summary>
        /// Quantity customer is requesting
        /// </summary>
        public int WantedQuantity { get; set; }
        /// <summary>
        /// Amount of the product in the macihe
        /// </summary>
        public int InMachine { get; set; }
        /// <summary>
        /// If <see cref="VendingMachine"/> has Product on stock
        /// </summary>
        public bool OnStock { get; set; }

        /// <summary>
        /// Product's Delivery
        /// </summary>
        private Delivery Delivery { get; set; }
        /// <summary>
        /// Order more products
        /// </summary>
        /// <returns>Time until on stock</returns>
        public string OrderMore(int OrderNumber)
        {
            //If there's enough in machine already
            if (InMachine == 25)
                return "Maximum products in machine! You can only order from 25 and below.";

            //If delivery time has passed
            if (DateTime.Now > Delivery.TimeTillArrival)
            {
                InMachine += Delivery.ProductsOnDelivery;
                Delivery.ProductsOnDelivery = 0;
                Delivery.InProcess = false;
                return "Stock updated!";
            }

            //Update Delivery
            while (OrderNumber != 0 || InMachine + Delivery.ProductsOnDelivery <= 25)
            {
                Delivery.ProductsOnDelivery++;
                OrderNumber--;
            }
            Delivery.InProcess = true;
            Delivery.TimeTillArrival = DateTime.Now.AddDays(2);

            //Return delivery response
            if (Delivery.ProductsOnDelivery == 1)
                return $"Delivery has been made. 1 {Name} is on its way.";
            return $"Delivery has been made. {Delivery.ProductsOnDelivery} {Name} is on its way.";
        }
        /// <summary>
        /// Calculate <see cref="WantedQuantity"/> * <see cref="Price"/>
        /// </summary>
        /// <returns>Calculated price</returns>
        public float CalculatePrice()
        {
            return WantedQuantity * Price;
        }
    }
}
