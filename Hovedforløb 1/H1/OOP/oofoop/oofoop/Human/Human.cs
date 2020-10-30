using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oofoop
{
    public class Human
    {
        public Human(string Name, float Cash, CreditCard Card, SmartPhone Phone)
        {
            this.Name = Name;
            this.Cash = Cash;
            this.Card = Card;
            this.Phone = Phone;
        }

        public string Name { get; set; }
        public float Cash { get; set; }
        public CreditCard Card { get; set; }
        public SmartPhone Phone { get; set; }
    }
}