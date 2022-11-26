using System;

namespace Personel
{
    public class Student : Personel
    {
        public Student(string Navn, int ID)
        {
            this.Navn = Navn;
            this.ID = ID;
        }
        /// <summary>
        /// Sometimes we'd all like some refreshment throughout the day
        /// </summary>
        /// <returns>Navn kom tilbage med {Refreshment}</returns>
        public override string GetRefreshment()
        {
            Refreshment = "Monster Energy";
            if (new Random().Next(2) == 0)
                return $"{Navn} kom tilbage med {Refreshment}.";
            else if (new Random().Next(2) == 1)
                return $"{Navn} kom tilbage med McDonalds.";
            return $"{Navn} kom tilbage med kage.";
        }
    }
}