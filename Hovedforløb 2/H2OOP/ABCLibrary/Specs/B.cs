using ABCLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABCLibrary.Specs
{
    public abstract class B
    {
        /// <summary>
        /// Returns the <see cref="Pokémon"/> in <see cref="InnerTeam"/> depending on <paramref name="index"/>
        /// </summary>
        /// <param name="index">Index of <see cref="Pokémon"/> from <see cref="InnerTeam"/></param>
        /// <returns><see cref="Pokémon"/> from <see cref="InnerTeam"/></returns>
        public ITeamMember this[int index]
        {
            get
            {
                try { return InnerTeam[index]; }
                catch (ArgumentOutOfRangeException) { throw new InvalidTeamIndexException($"Number invalid. Must be from range 1 - {InnerTeam.Count}."); }
            }
        }

        /// <summary>
        /// Official list of <see cref="Pokémon"/>
        /// </summary>
        protected List<ITeamMember> InnerTeam { get => DB.GetFileContent().ToList(); set => DB.SaveFileWith(value.ToArray()); }
        /// <summary>
        /// Last <see cref="ITeamMember"/> to be added to <see cref="InnerTeam"/>
        /// </summary>
        public ITeamMember LastAdded => InnerTeam[InnerTeam.Count - 1];
        public FileHandler DB { get; private set; }
        public B(string fileName) => DB = new FileHandler(fileName, new ITeamMember[6]);
        /// <summary>
        /// Adds <paramref name="pkmn"/> to <see cref="InnerTeam"/>
        /// </summary>
        /// <param name="pkmn"><see cref="Pokémon"/> to add</param>
        public virtual void Add(ITeamMember tm)
        {
            List<ITeamMember> temp = InnerTeam;
            if(temp.Count == 6)
                
            temp.Add(tm);
            DB.SaveFileWith(temp.ToArray());
        }
        /// <summary>
        /// Removes <paramref name="tm"/> from <see cref="InnerTeam"/>
        /// </summary>
        /// <param name="tm"></param>
        public virtual void Remove(ITeamMember tm)
        {
            InnerTeam.Remove(tm);
            DB.SaveFileWith(InnerTeam.ToArray());
        }
        /// <summary>
        /// Lists all <see cref="Pokémon"/> in <see cref="InnerTeam"/> as .ToString()
        /// </summary>
        /// <returns>string[] of <see cref="Pokémon"/>'s .ToString()</returns>
        public string[] View()
        {
            string[] result = new string[InnerTeam.Count];
            for (int x = 0; x < InnerTeam.Count; x++)
                result[x] = InnerTeam[x].ToString();
            return result;
        }

        public List<ITeamMember> GetMembers() => (from ITeamMember tm in InnerTeam select tm).ToList();
    }
}
