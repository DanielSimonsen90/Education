namespace Personel
{
    public abstract class Personel
    {
        public int ID;
        public string Navn, Password, Refreshment;
        public abstract string GetRefreshment();
    }
}
