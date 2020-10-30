using System;
using System.Collections.Generic;
using System.Timers;
using DanhoLibrary;
using ABCLibrary.Interfaces;
using System.Runtime.CompilerServices;

namespace ABCLibrary
{
    /// <summary>
    /// Trainer that plays the game, C
    /// </summary>
    public class Trainer : Specs.C
    {
        #region Properties
        /// <summary>
        /// Name of <see cref="this"/>
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Age of <see cref="this"/>
        /// </summary>
        public int Age { get => 10; }
        /// <summary>
        /// Returns Team members as their l.ToString()
        /// </summary>
        public string[] TeamAsStrings => Team.View();
        /// <summary>
        /// Eggs in <see cref="this"/>'s possesion
        /// </summary>
        public Egg[] Eggs => ((Team)Team).GetEggs();
        /// <summary>
        /// Members in <see cref="this.Team"/>
        /// </summary>
        public List<ITeamMember> TeamMembers => Team.GetMembers();
        /// <summary>
        /// Last added <see cref="ITeamMember"/> to <see cref="this.Team"/>
        /// </summary>
        public ITeamMember LastAdded => Team.LastAdded;
        #endregion

        /// <summary>
        /// Sets name & initates <see cref="Team"/> with <paramref name="starter"/>
        /// </summary>
        /// <param name="name">Name of Trainer</param>
        /// <param name="starter">Starter the User chose</param>
        public Trainer(string name, Pokémon starter, string fileName) : base(new Team(fileName, starter)) => Name = name;

        public Pokémon GetPokémon(int index) => (Pokémon)Team[index];
        public void AddEncounter(ITeamMember encounter) => Team.Add(encounter);
        public void RemoveTeamMember(ITeamMember member) => Team.Remove(member);
        
        /// <summary>
        /// <paramref name="onEggHatch"/> runs when <paramref name="egg"/> hatches
        /// </summary>
        /// <param name="egg"></param>
        /// <param name="onEggHatch"></param>
        public void SetEggHatch(Egg egg, EggHatching onEggHatch) => egg.OnEggHatch += onEggHatch;
    }
}