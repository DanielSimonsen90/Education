namespace MIG.Song
{
    public class Genre
    {
        #region Variables
        public string Name { get; }
        public Scale Scale;
        public BPM BPM { get; set; }
        public Drums Drums { get; }
        public Synths Synths { get; }
        public Instruments Instruments { get; }
        #endregion

        public Genre(string name, int[] BPMRange, Drums drums, Synths synths, Instruments instruments)
        {
            Name = name;
            Scale = new Scale(50);
            BPM = new BPM(BPMRange);
            Drums = drums;
            Synths = synths;
            Instruments = instruments;
            Elements = new IGetInfoInterface[] { Drums, Synths, Instruments };
        }

        public override string ToString() => Name;
    }

}