namespace MIG.Song
{
    public class Drums
    {
        public string Kick { get; }
        public string Clap { get; }
        public string Hihat { get; }
        public string OpenHat { get; }
        public string Snare { get; }

        public Drums(KickOptions kick, ClapOptions clap, HihatOptions hihat, OpenHatOptions openHat, SnareOptions snare)
        {
            Kick = ConvertConstructor(kick);
            Clap = ConvertConstructor(clap);
            Hihat = ConvertConstructor(hihat);
            OpenHat = ConvertConstructor(openHat);
            Snare = ConvertConstructor(snare);
        }

        private static string ConvertConstructor(KickOptions kick) =>
            kick switch
            {
                KickOptions.Acoustic => "Acoustic",
                KickOptions.Punchy => "Punchy",
                KickOptions.Lofi => "Lofi",
                KickOptions.Distorted => "Distorted",
                KickOptions.Trance => "Trance",
                KickOptions.Clubby => "Clubby",
                _ => "Unidentified",
            };
        private static string ConvertConstructor(ClapOptions clap) =>
            clap switch
            {
                ClapOptions.Tight => "Tight",
                ClapOptions.Main => "Main",
                ClapOptions.Trap => "Trap",
                ClapOptions.Huge => "Huge",
                _ => "Unidentified",
            };
        private static string ConvertConstructor(HihatOptions hihat) =>
            hihat switch
            {
                HihatOptions.Acoustic => "Acoustic",
                HihatOptions.Tick => "Tick",
                HihatOptions.Lofi => "Lofi",
                _ => "Unidentified",
            };
        private static string ConvertConstructor(OpenHatOptions openHat) =>
            openHat switch
            {
                OpenHatOptions.Acoustic => "Acoustic",
                OpenHatOptions.House => "House",
                OpenHatOptions.Clubby => "Clubby",
                _ => "Unidentified",
            };
        private static string ConvertConstructor(SnareOptions snare) =>
            snare switch
            {
                SnareOptions.Acoustic => "Acoustic",
                SnareOptions.House => "House",
                SnareOptions.Lofi => "Lofi",
                SnareOptions.FutureBass => "Future Bass",
                SnareOptions.Trap => "Trap",
                SnareOptions.Clubby => "Clubby",
                _ => "Unidentified",
            };
    }

    public enum KickOptions { Acoustic, Punchy, Lofi, Distorted, Trance, Clubby }
    public enum ClapOptions { Tight, Main, Trap, Huge }
    public enum HihatOptions { Acoustic, Tick, Lofi }
    public enum OpenHatOptions { Acoustic, House, Clubby }
    public enum SnareOptions { Acoustic, House, Lofi, FutureBass, Trap, Clubby }
}