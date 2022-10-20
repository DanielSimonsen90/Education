using ABCLibrary.Interfaces;
using DanhoLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ABCLibrary
{
    public class FileHandler
    {
        private string FileName { get; set; }
        public ITeamMember[] Members { get => GetFileContent(); set => SaveFileWith(value); }

        public FileHandler(string fileName, ITeamMember[] members)
        {
            FileName = fileName;
            SaveFileWith(members);
        }

        /// <summary>
        /// Returns the list of Pokémon saved from <see cref="FileName"/>
        /// </summary>
        /// <returns></returns>
        public ITeamMember[] GetFileContent()
        {
            string[] stringTeam = File.ReadAllText(FileName).Split('\n');
            ITeamMember[] memberTeam = new ITeamMember[6];
            for (int mbmr = 0; mbmr < stringTeam.Length; mbmr++)
            {
                List<string> props = stringTeam[mbmr].Split(',').ToList();
                if (props[0] == string.Empty)
                    continue;

                props.RemoveAt(props.Count - 1);

                switch (props.Count)
                {
                    case 1: memberTeam[mbmr] = new Egg(props[0]); break;
                    case 3: memberTeam[mbmr] = new Pokémon(props[0], int.Parse(props[2]), props[1].Split('/')); break;
                    case 4: memberTeam[mbmr] = new Pokémon(props[0], int.Parse(props[2]), props[1].Split('/')) { HatchedFrom = new Egg(props[4]) }; break;
                    default: throw new Exception("Ran default switch in FileHandler.GetFileContent() using " + props.Join(","));
                }
            }
            return memberTeam;
        }
        /// <summary>
        /// Updates <see cref="FileName"/> content with <paramref name="members"/>
        /// </summary>
        /// <param name="members">New value</param>
        public void SaveFileWith(ITeamMember[] members)
        {
            File.WriteAllText(FileName, "");

            StringBuilder sb = new StringBuilder();
            foreach (ITeamMember member in members)
            {
                if (member == null) continue;
                else if (member.GetType() == typeof(Pokémon))
                {
                    var pkmn = (Pokémon)member;
                    sb.Append($"{pkmn.Name},{pkmn.GetTypings()},{pkmn.Level},{pkmn.HeldItem}");
                    sb.Append((pkmn.HatchedFrom != null) ? $",{pkmn.HatchedFrom.Name}\n" : "\n");
                        
                }
                else
                {
                    var egg = (Egg)member;
                    sb.Append(egg.ToString());
                }
            }

            File.AppendAllText(FileName, sb.ToString());
        }
        /// <summary>
        /// Deletes <see cref="FileName"/>
        /// </summary>
        public void DeleteFile() => File.Delete(FileName);
    }
}