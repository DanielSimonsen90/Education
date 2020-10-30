using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oofoop
{
    public class MobilePay
    {
        public MobilePay(CreditCard card)
        {
            Card = card;
        }

        public bool HasApp { get; set; }
        public bool HasConnection { get; set; }
        private CreditCard Card { get; }

        public string AttemptPayment(float amount)
        {
            if (Card.OnAccount < amount)
                return "failed";
            Card.OnAccount -= amount;
            return "successful";
        }
    }
}
