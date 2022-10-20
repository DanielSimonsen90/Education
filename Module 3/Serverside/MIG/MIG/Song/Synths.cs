namespace MIG.Song
{
    public class Synths
    {
        public Synth Arp { get; set; }
        public Synth Lead { get; set; }
        public Synth Chords { get; set; }
        public Synth Bass { get; set; }

        public Synths(bool arp, bool lead, bool chords, bool bass)
        {
            if (arp) Arp = new();
            if (lead) Lead = new();
            if (chords) Chords = new();
            if (bass) Bass = new();
        }
        public Synths() : this(true, true, true, true) {}
    }
}