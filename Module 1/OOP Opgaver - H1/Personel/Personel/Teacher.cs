using System;
using System.Linq;

namespace Personel
{
    public class Teacher : Personel
    {
        public Teacher(string Navn, int ID, string[] Speciality)
        {
            this.Navn = Navn;
            this.ID = ID;
            this.Speciality = Speciality;
        }

        /// <summary>
        /// All teachable subjects
        /// </summary>
        readonly string[] AvailableSubjects = new string[] { "Programming", "Math", "Danish", "English" };
        /// <summary>
        /// Teacher's Speciality/ies
        /// </summary>
        public readonly string[] Speciality;

        /// <summary>
        /// Teacher educating <paramref name="Klassen"/> in <paramref name="Subject"/>
        /// </summary>
        /// <param name="Klassen">Class to teach</param>
        /// <param name="Subject">Subjec to teach <paramref name="Klassen"/></param>
        /// <returns>Education result</returns>
        public string Educate(Student[] Klassen, string Subject)
        {
            Random rand = new Random();
            string result = $"{Navn} lærte {nameof(Klassen)} {Subject}, ";

            if (!AvailableSubjects.Contains(Subject))
                return $"\"{Subject}\" er ikke en del af {nameof(AvailableSubjects)}.";
            else if (!Speciality.Contains(Subject))
                return $"{Navn} blev en vikar for {nameof(Klassen)} til {Speciality}.";

            switch (rand.Next(5))
            {
                case 1:
                    result += $"men {Klassen[rand.Next(Klassen.Length)].Navn} skabte nogle problemer...";
                    break;
                case 2:
                    result += "men blev desværre syg i løbet af dagen.";
                    break;
                case 3:
                    result += "og gav dem lektier for.";
                    break;
                case 4:
                    result += "og endte med at give dem tidligere fri, da de havde arbejdet virkelig godt i løbet af dagen.";
                    break;
                default:
                    return Educate(Klassen, Subject);
            }
            return result;
        }

        public override string GetRefreshment()
        {
            Refreshment = "Kaffe";
            if (new Random().Next(2) == 1)
                return $"{Navn} kom tilbage med {Refreshment}.";
            return $"{Navn} kom tilbage med kage.";
        }
    }
}