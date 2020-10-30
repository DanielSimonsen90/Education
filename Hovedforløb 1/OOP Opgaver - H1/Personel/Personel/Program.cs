using DanhoLibrary;
using System;

namespace Personel
{
    class Program
    {
        #region Klasse / Student
        static readonly Student[] Klasse = GetKlasse();
        /// <summary>
        /// Data for <see cref="Klasse"/>
        /// </summary>
        /// <returns><see cref="Klasse"/> data</returns>
        static Student[] GetKlasse()
        {
            Student[] H1 = new Student[]
            {
                new Student("Lasse", 1){Password = "SlothsAreLovable", Refreshment = "Kakao"},
                new Student("Nikolai", 2) {Password = "AmMissingKidney", Refreshment = "Kaffe"},
                new Student("Andreas V", 3){Password = "MYANUSBEBLEEDING", Refreshment = "Kaffe"},
                new Student("Daniel", 4){Password = "omegalulUwU", Refreshment = "Kaffe"},
                new Student("Viktor", 5){Password = "Alkohol4Æver"},
                new Student("Jesper", 6){Password = "Mac?"},
                new Student("Andreas K.", 7){Password = "MYANUSISALSOBLEEDING"},
                new Student("Michael", 8){Password = "MeLikeWalkz", Refreshment = "Mathilde"},
                new Student("Peter", 9){Password = "HardwareIsLife"},
                new Student("Alexander", 10){Password = "IAmWeeb", Refreshment = "Mountain Dew"},
                new Student("Anders", 11){Password = "IAmSleepy", Refreshment = "Saftevand <o/"},
                new Student("Emil", 12){Password = "JegVilGerneLæreNogetPLS", Refreshment = "Redbull"},
                new Student("Omid", 13){Password = "DressingSmagerGodt", Refreshment = "Redbull"},
                new Student("Rasmus", 14){Password = "AirPodsForLife", Refreshment = "Booster"},
                new Student("Oliver", 15){Password = "Hello", Refreshment = "Booster"},
            };
            return H1;
        }

        static void DefaultMenu(string[] Options, Student student)
        {
            ConsoleItems.Title($"Velkommen tilbage, {student.Navn}");
            ConsoleItems.ListOptions(Options);
        }
        static void Menu(Student User)
        {
            Console.Clear();
            DefaultMenu(new string[] { "Go to class", "Get refreshment", "Exit" }, User);
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("You went to class. Have fun!");
                    return;
                case "2":
                    Console.WriteLine(User.GetRefreshment());
                    return;
                default:
                    return;
            }
        }
        #endregion

        #region Lærer / Teacher
        static readonly Teacher[] Lærere = GetLærere();
        /// <summary>
        /// Data for <see cref="Lærere"/>
        /// </summary>
        /// <returns><see cref="Lærere"/> data</returns>
        static Teacher[] GetLærere()
        {
            return new Teacher[]
            {
                new Teacher("Lærke", 1, new string[]{"Programming"}){ Password = "GitteForEver"},
                new Teacher("Lars", 2, new string[]{"Programming", "Math"}){Password = "LigeÉnSidsteTing"},
                new Teacher("Kamala", 3, new string[]{"Danish"}){Password = "#332211"},
                new Teacher("Liselotte", 4, new string[]{"English"}){Password = "YnglingsElev420"}
            };
        }

        static void DefaultMenu(string[] Options, Teacher teacher)
        {
            ConsoleItems.Title($"Velkommen tilbage, {teacher.Navn}");
            ConsoleItems.ListOptions(Options);
        }
        static void Menu(Teacher User)
        {
            Console.Clear();
            DefaultMenu(new string[] { "Educate students", "Get refreshment", "Exit" }, User);
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine(User.Educate(Klasse, User.Speciality[new Random().Next(User.Speciality.Length)]));
                    return;
                case "2":
                    Console.WriteLine(User.GetRefreshment());
                    return;
                default:
                    return;
            }
        }
        #endregion

        /// <summary>
        /// Login to program
        /// </summary>
        /// <returns>Class of login user</returns>
        static void Login()
        {
            Console.Clear();
            try
            {
                //User Interface and Interaction
                Console.Write("ID: ");
                int ID = Convert.ToInt32(Console.ReadLine());
                Console.Write("Password: ");
                string Password = Console.ReadLine();

                Console.Clear();

                //Login Student
                foreach (Student Elev in Klasse)
                    if (Elev.ID == ID && Elev.Password == Password)
                    {
                        Menu(Elev);
                        return;
                    }

                //Login Teacher
                foreach (Teacher Lærer in Lærere)
                    if (Lærer.ID == ID && Lærer.Password == Password)
                    {
                        Menu(Lærer);
                        return;
                    }

                //If neither Student or Teacher login recognized, login failed.
                Console.Clear();
                ConsoleItems.Error("Login failed! Please try again");
                Login();
            }
            catch
            {
                Console.Clear();
                ConsoleItems.Error("Please login again!");
                Login();
            }
        }

        static void Main()
        {
            while (true)
            {
                Login();
                Console.ReadKey();
            }
        }
    }
}
