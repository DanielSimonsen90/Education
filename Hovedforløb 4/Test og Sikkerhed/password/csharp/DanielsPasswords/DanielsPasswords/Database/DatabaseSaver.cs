using System.Collections.Generic;

namespace DanielsPasswords.Database
{
    public abstract class DatabaseSaver<Item> where Item : Login
    {
        public abstract void Die();
        public abstract List<Item> AddData(Item item);
        public abstract List<Item> DeleteData(Item item);
        public abstract List<Item> FetchData();
    }
}
