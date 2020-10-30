using System.Collections.Generic;

namespace Storage
{
    class Item
    {
        public int ID, Amount;
        public string Name;

        #region Constructors
        private Item(string Name, int Amount)
        {
            this.Name = Name;
            this.Amount = Amount;
        }
        public Item(string Name, int Amount, List<Item> Storage) 
            : this(Name, Amount) => ID = NextID(Storage);
        public Item(string Name, int Amount, int ID)
            : this(Name, Amount) => this.ID = ID;
        #endregion

        private int NextID(List<Item> Storage)
        {
            //Does Storage already contain Item?
            foreach (Item Product in Storage)
                if (Product.Name == Name)
                    return Product.ID;

            if (Name == "null")
                return -1;
            return Storage.Count + 1;
        }
    }
}
