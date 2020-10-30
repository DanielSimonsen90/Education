using DanhoLibrary;
using ABCLibrary;

using System;
using ABCLibrary.Interfaces;
using System.Collections.Generic;
using ABCLibrary.Specs;

namespace H2OOP
{
    /// <summary>
    /// The UI for Console Application, D
    /// </summary>
    public class ConsoleUI : D
    {
        /// <summary>
        /// ConsoleUI's Main()
        /// </summary>
        public ConsoleUI()
        {
            WelcomeScreen();
            Trainer = DefineTrainer(
                Pokémon.PokémonAvailable[0], //Bulbasaur
                Pokémon.PokémonAvailable[1], //Squirtle
                Pokémon.PokémonAvailable[2]); //Charmander
            Console.Clear();
            while (true) ModifyTeam();
        }

        /// <summary>
        /// The nice welcome screen to the user
        /// </summary>
        private void WelcomeScreen() => ConsoleItems.Title("Simonsen Techs Pokémon game", "Welcome to the glorious world of Pokémon!");

        /// <summary>
        /// Defines the user's <see cref="H2OOP.Trainer"/> rank
        /// </summary>
        /// <param name="starterOne">First starter</param>
        /// <param name="starterTwo">Second starter</param>
        /// <param name="starterThree">Third starter</param>
        /// <returns>Trainer</returns>
        private Trainer DefineTrainer(Pokémon starterOne, Pokémon starterTwo, Pokémon starterThree)
        {
            Console.WriteLine("What is your name?");
            string username = Console.ReadLine();
            Console.WriteLine();
            try
            {
                Pokémon starter = GetStarter(starterOne, starterTwo, starterThree);
                Console.WriteLine($"You chose {starter.Name}!");
                Console.ReadKey(true);
                return new Trainer(username, starter, "playerTeam.txt");
            }
            catch (OverflowException)
            {
                Console.Clear();
                Console.WriteLine(username + ", you took too long to pick a starter!");
                return null;
            }
        }
        /// <summary>
        /// Defines <see cref="Trainer"/>'s starter pokemon
        /// </summary>
        /// <param name="starters">Starters possible</param>
        /// <returns><see cref="Trainer"/>'s starter</returns>
        private Pokémon GetStarter(params Pokémon[] starters)
        {
            //Get Choice
            Console.WriteLine("Which of the following pokémon would you like as a starter?");
            ConsoleItems.ListOptions(starters);
            ConsoleItems.Choice = Console.ReadLine();

            //if number value
            if (int.TryParse(ConsoleItems.Choice, out int num))
                if (num > 3 || num < 1)
                {
                    Console.WriteLine("Please select a valid starter!");
                    return GetStarter(starters);
                }
                else return starters[--num];
            for (int x = 0; x < 3; x++)
                if (ConsoleItems.Choice.ToLower()[0] == starters[x].ToString().ToLower()[0]) //if char value
                    return starters[x];
            return GetStarter(starters);
        }

        /// <summary>
        /// User interaction with CRUD
        /// </summary>
        private void ModifyTeam()
        {
            ConsoleItems.Title("Modify Team", "What would you like to do?");
            ConsoleItems.ListOptions(out int Choice, 
                "View Team", 
                "Add to team (catch)", 
                "Update a Team member's Held item", 
                "Remove from team");
            Console.WriteLine();
            switch (Choice)
            {
                case 1: ViewTeam(); break;
                case 2: Encounter(); break;
                case 3: UpdateAHeldItem(); break;
                case 4: RemoveFromTeam(); break;
                case 5: EggHatching(); break;
                default: break;
            }
            Console.Clear();
        }

        #region CRUD
        #region Encounter
        /// <summary>
        /// User encounters a <see cref="Pokémon"/> or <see cref="Egg"/>
        /// </summary>
        public void Encounter()
        {
            ITeamMember tm = new List<ITeamMember>(Pokémon.PokémonAvailable) { new Egg() }.GetRandomItem();
            Console.Clear();

            if (tm.GetType() == typeof(Egg))
            {
                UserPresentedEncounter((Egg)tm,
                    $"You've stumbled upon an Egg! \n" +
                    $"Would you like to add it to your team?",
                    "Egg was added to team!");
                //Trainer is a C, which is converted to a Trainer class
                //Trainer has .Team which as .LastAdded - but .LastAdded is ITeamMember
                //.LastAdded is an egg (we know this by tm.GetType()) and therefore needs to be casted as a egg, so its .OnEggHatch can be set to OnEggHatched
                ((Trainer)Trainer).SetEggHatch((Egg)tm, OnEggHatched);
                return;
            }

            Pokémon pkmn = (Pokémon)tm;

            //Define Encounter
            string typeOrTypes = pkmn.Types.Length != 1 ? "types" : "type";

            UserPresentedEncounter(pkmn,
                $"A wild {pkmn.Name} appeared!\n" +
                $"{pkmn.Name}'s {typeOrTypes}: {pkmn.GetTypings()}" +
                $"Assumingly around level {pkmn.RandomLevel}\n\n" +
                $"Would you like to catch it?",
                $"You caught the lvl {pkmn.Level} {pkmn.Name}.");
        }
        /// <summary>
        /// The presentable UI to <see cref="Encounter"/>
        /// </summary>
        /// <param name="Encounter">Encounter mon</param>
        /// <param name="EncounterMessage">You've encounted <paramref name="Encounter"/>!</param>
        /// <param name="CatchMessage">You've caught <paramref name="Encounter"/>!</param>
        private void UserPresentedEncounter(ITeamMember Encounter, string EncounterMessage, string CatchMessage)
        {
            //Present Encounter
            Console.WriteLine(EncounterMessage);
            ConsoleItems.Choice = Console.ReadLine();

            //Does user NOT want it?
            if (ConsoleItems.Choice.ToLower()[0] == 'n') return;

            Console.WriteLine(CatchMessage);
            ((Trainer)Trainer).AddEncounter(Encounter);
            Console.ReadKey(true);
        }
        #endregion
        /// <summary>
        /// Goes through UI to edit a <see cref="Pokémon"/> in <see cref="Team"/>'s held item
        /// </summary>
        public void UpdateAHeldItem()
        {
            #region GetPokémon
            ConsoleItems.ListOptions(((Trainer)Trainer).TeamAsStrings);
            Console.WriteLine();
            Console.WriteLine("Which of the following Pokémon holds the item you want to change?");
            int.TryParse(Console.ReadLine(), out int result);
            Pokémon pkmn = (Pokémon)((Trainer)Trainer).GetPokémon(--result);
            #endregion

            #region UpdateItem
            Console.Clear();
            if (string.IsNullOrEmpty(pkmn.HeldItem)) Console.WriteLine($"Which item would you like to give {pkmn.Name}?");
            else Console.WriteLine($"What would you like to change {pkmn.Name}'s {pkmn.HeldItem} to?");
            string preItem = pkmn.HeldItem;
            pkmn.HeldItem = Console.ReadLine();
            if (string.IsNullOrEmpty(pkmn.HeldItem)) Console.WriteLine($"\"{preItem}\" was removed from {pkmn.Name}.");
            else Console.WriteLine($"{pkmn.Name}'s \"{preItem}\" was updated to {pkmn.HeldItem}.");
            Console.ReadKey(true);
            #endregion
        }
        /// <summary>
        /// Lists all pokemon in <see cref="Team"/>
        /// </summary>
        public void ViewTeam()
        {
            ConsoleItems.ListOptions(((Trainer)Trainer).TeamAsStrings);
            Console.WriteLine();
            Console.ReadKey(true);
        }
        /// <summary>
        /// Removes user specified <see cref="Pokémon"/> from team if possible
        /// </summary>
        public void RemoveFromTeam()
        {
            Console.WriteLine("Which of the following Pokémon would you like to remove?");
            ConsoleItems.ListOptions(out int Choice, ((Trainer)Trainer).TeamAsStrings);
            Pokémon Removed = (Pokémon)((Trainer)Trainer).GetPokémon(--Choice);
            try { ((Trainer)Trainer).RemoveTeamMember(Removed); Console.WriteLine($"\n{Removed.Name} was removed from team."); }
            catch (UnableToRemoveException e) { Console.WriteLine(e.Message); }
            Console.ReadKey(true);
        }
        #endregion

        #region Egg Hatching
        private void OnEggHatched(Egg egg)
        {
            Console.Clear();
            Console.Write("Oh?");
            ConsoleItems.Wait(2000);
            Console.WriteLine(" An egg is hatching!");
            ConsoleItems.Waiting(3, 1000);

            foreach (ITeamMember tm in ((Trainer)Trainer).TeamMembers)
                if (tm.GetType() == typeof(Pokémon) && ((Pokémon)tm).HatchedFrom == egg)
                    Console.WriteLine($"It hatched into a {((Pokémon)tm).Name}!");
            Console.ReadKey(true);
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void EggHatching()
        {
            if (Console.BackgroundColor == ConsoleColor.Black)
            {
                Console.WriteLine("No Egg is hatching right now.");
                Console.ReadKey(true);
                return;
            }

            //Trainer is  C class (inheritet from Specs.D), which needs to be converted into a Trainer class
            //Trainer has .Team, which is a B class that needs to be converted into a Team class
            //Team has .GetEggs()
            foreach (Egg egg in ((Trainer)Trainer).Eggs)
                if (egg.IsHatching)
                    OnEggHatched(egg);
        }
        #endregion
    }
}