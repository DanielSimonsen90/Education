using DanhoLibrary.Extensions;
using System.Collections.Generic;

namespace MIG.Song
{
    public class Instruments
    {
        public bool Piano { get; set; }
        public bool Guitar { get; set; }
        public bool Horns { get; set; }
        public bool Strings { get; set; }

        public List<string> AllInstruments => new List<string>()
        {
            Piano ? "Piano" : null,
            Guitar ? "Guitar" : null,
            Horns ? "Horns" : null,
            Strings ? "Strings" : null
        }.Filter((v, i, arr) => v != null) as List<string>;

        public Instruments(bool piano, bool guitar, bool horns, bool strings)
        {
            Piano = piano;
            Guitar = guitar;
            Horns = horns;
            Strings = strings;
        }
    }
}