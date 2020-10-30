using System;

namespace oofoop
{
    public class Delivery
    {
        public int ProductsOnDelivery { get; set; }
        public bool InProcess { get; set; }
        public DateTime TimeTillArrival { get; set; }
    }
}