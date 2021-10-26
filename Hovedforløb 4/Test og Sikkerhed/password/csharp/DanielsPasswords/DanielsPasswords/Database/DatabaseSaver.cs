using System.Collections.Generic;

namespace DanielsPasswords.Database
{
    public abstract class DatabaseSaver<Item> where Item : Login
    {
        protected List<Item> Cache { get; set; }

        public abstract void Die();
        public abstract List<Item> AddData(Item item);
        public abstract List<Item> DeleteData(Item item);
        public virtual List<Item> GetData() => Cache.Count == 0 ? Cache = FetchData() : Cache;
        public abstract List<Item> FetchData();
    }
}
