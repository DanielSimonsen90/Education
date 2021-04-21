namespace MIG.Song
{
    public class Genre
    {
        public string Title { get; set; }
        public BPM BPM { get; set; }
        public Drums Drums { get; set; }
        public Synths Synths { get; set; }
        public Instruments Instruments { get; set; }

        public Genre(string title, int bpmMin, int bpmMax, Drums drums, Synths synths, Instruments instruments)
        {
            Title = title;
            BPM = new(bpmMin, bpmMax);
            Drums = drums;
            Synths = synths;
            Instruments = instruments;
        }
    }
}