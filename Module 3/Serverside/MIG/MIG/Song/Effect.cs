namespace MIG.Song
{
    public static class Effect
    {
        public static string Chorus { get; } = "Chorus";
        public static string Delay { get; } = "Delay";
        public static string Distortion { get; } = "Distortion";
        public static string Flanger { get; } = "Flanger";
        public static string Reverb { get; } = "Reverb";

        public static string[] AllEffects => new string[] { Chorus, Delay, Distortion, Flanger, Reverb };
    }
}