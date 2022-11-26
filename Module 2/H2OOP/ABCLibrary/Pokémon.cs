using DanhoLibrary;
using System.Collections.Generic;

namespace ABCLibrary
{
    /// <summary>
    /// Pokémon "item" in game, A
    /// </summary>
    public sealed class Pokémon : Specs.A
    {
        public static readonly List<Pokémon> PokémonAvailable = new List<Pokémon>
        {
            new Pokémon("Bulbasaur", "Grass", "Poison"),
            new Pokémon("Squirtle", "Water"),
            new Pokémon("Charmander", "Fire"),
            new Pokémon("Caterpie", "Bug"),
            new Pokémon("Weedle", "Bug"),
            new Pokémon("Pidgey", "Normal", "Flying"),
            new Pokémon("Rattata", "Normal"),
            new Pokémon("Spearow", "Normal", "Flying"),
            new Pokémon("Ekans", "Poison"),
            new Pokémon("Koffing", "Poison")
        };
        public int RandomLevel 
        { 
            get
            {
                if (_randomLevel == 0)
                    while (_randomLevel < 1)
                        _randomLevel = ConsoleItems.RandomNumber(Level - 5, Level + 5);
                return _randomLevel;
            }
        }
        private int _randomLevel = 0;

        #region Properties
        /// <summary>
        /// Level of <see cref="this"/>
        /// </summary>
        public int Level { get; }
        /// <summary>
        /// Type(s) of <see cref="this"/>
        /// </summary>
        public string[] Types { get; }
        /// <summary>
        /// The Item the <see cref="Pokémon"/> is holding
        /// </summary>
        public string HeldItem { get; set; }
        /// <summary>
        /// If <see cref="this"/> was hatched from an <see cref="Egg"/>, returns <see cref="Egg"/> object
        /// </summary>
        public Egg HatchedFrom { get; set; }
        #endregion

        /// <summary>
        /// <see cref="Name"/> is set to <paramref name="Name"/>, <see cref="Types"/> is set to <paramref name="Types"/> if <paramref name="Types"/> isn't null - <see cref="Level"/> is randomized
        /// </summary>
        /// <param name="Name">Name of <see cref="this"/></param>
        /// <param name="Types">Pokémon typings</param>
        public Pokémon(string Name, params string[] Types) : base(Name)
        {
            if (Types.Length == 0) throw new NoTypingsException($"Type(s) not defined!", this);
            this.Types = Types;
            Level = ConsoleItems.RandomNumber(1, 15);
        }
        public Pokémon(string Name, int Level, params string[] Types) : this(Name, Types) => this.Level = Level;

        #region ToString elements
        /// <summary>
        /// Overwritten with Name [Type1/Type2] (Level)
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{Name} [{GetTypings()}] ({Level}) {GetHeldItem()}"; //Bulbasaur [Grass/Poison] (5) @ Leftovers
        /// <summary>
        /// If Type[1] isn't null, returns "Type[0]/Type[1]", else "Type[0]"
        /// </summary>
        /// <returns></returns>
        public string GetTypings() => (Types.Length == 1) ? Types[0] : $"{Types[0]}/{Types[1]}";
        /// <summary>
        /// Presents the Held item in @ item format
        /// </summary>
        /// <returns></returns>
        private string GetHeldItem() => string.IsNullOrEmpty(HeldItem) ? string.Empty : $"@ {HeldItem}";
        #endregion
    }
}