using System;

namespace oofoop
{
    public class CreditCard
    {
        public CreditCard(string Holder, float OnAccount)
        {
            CardNumber = CreateCardNumber();
            this.Holder = Holder;
            this.OnAccount = OnAccount;
        }

        public string CardNumber, Holder;
        public float OnAccount;
        
        /// <summary>
        /// Creates random CardNumber
        /// </summary>
        /// <returns><see cref="CardNumber"/></returns>
        private string CreateCardNumber()
        {
            string nr = new Random().Next(9).ToString();
            for (var i = 1; i <= 16; i++)
            {
                nr += new Random().Next(9).ToString();
                if (i == 3 || i == 7 || i == 11)
                    nr += " ";
            }
            return nr;
        }
        public void GetCash(Human human, float amount)
        {
            //If Human requests more cash than they have on card
            if (OnAccount < amount)
                return;

            float result = OnAccount - amount;
            OnAccount -= amount;
            human.Cash += result;
        }
        public void GetOnCard(Human human, float amount)
        {
            //If Human doesn't have enough Cash to transfer
            if (human.Cash < amount)
                return;

            float result = human.Cash - amount;
            human.Cash -= amount;
            OnAccount += result;
        }
    }
}