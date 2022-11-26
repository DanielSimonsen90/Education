using ABCLibrary.Interfaces;
using ABCLibrary.Specs;
using DanhoLibrary;
using System.Linq;

namespace ABCLibrary
{
    /// <summary>
    /// List of Pokémon, B
    /// </summary>
    public class Team : B
    {
        /// <summary>
        /// When Egg hatches, replace with new Pokémon from <see cref="Pokémon.PokémonAvailable"/>
        /// </summary>
        /// <param name="caller">Egg that called the event</param>
        public void OnEggHatched(Egg caller)
        {
            //Get hatched
            Pokémon hatched = null;
            while (hatched != null && hatched.GetType() != typeof(Egg))
                hatched = Pokémon.PokémonAvailable.GetRandomItem();

            //Remember hatched was from caller
            hatched.HatchedFrom = caller;

            //Replace caller's position in innerTeam with hatched
            InnerTeam[InnerTeam.IndexOf(caller)] = hatched;
        }

        public Team(string fileName, Pokémon starter) : base(fileName) => Add(starter);

        public override void Add(ITeamMember tm)
        {
            base.Add(tm);
            if (tm.GetType() == typeof(Egg))
                ((Egg)tm).OnEggHatch += OnEggHatched;
        }
        /// <summary>
        /// Updates the Held item, the <paramref name="pkmn"/> is holding with <paramref name="NewItem"/>
        /// </summary>
        /// <param name="pkmn">The pokémon that hold the item</param>
        /// <param name="NewItem">The new item to replace the old one</param>
        public void UpdateHeldItem(Pokémon pkmn, string NewItem)
        {
            pkmn.HeldItem = NewItem;
            DB.SaveFileWith(InnerTeam.ToArray());
        }
        /// <summary>
        /// Removes <paramref name="pkmn"/> from <see cref="innerTeam"/> if possible
        /// </summary>
        /// <param name="pkmn"><see cref="Pokémon"/> to remove</param>
        public override void Remove(ITeamMember tm)
        {
            if (InnerTeam.Contains(tm))
                if (InnerTeam.Count > 1)
                    base.Remove(tm);
                else throw new UnableToRemoveException($"{tm.Name} could not be removed, as it's your only Pokémon left!", tm);
            else throw new UnableToRemoveException($"Team doesn't contain {tm.Name}!", tm);
        }
        /// <summary>
        /// Returns all Eggs in <see cref="innerTeam"/>
        /// </summary>
        /// <returns></returns>
        public Egg[] GetEggs() => (from ITeamMember teamMember in InnerTeam
                                   where teamMember.GetType() == typeof(Egg)
                                   select teamMember as Egg).ToArray();
    }
}
