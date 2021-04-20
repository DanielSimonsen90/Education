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

        }

        private static string ConvertKick(KickOptions kick) =>
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

    }

    public enum KickOptions { Acoustic, Punchy, Lofi, Distorted, Trance, Clubby }
    public enum ClapOptions { Tight, Main, Trap, Huge }
    public enum HihatOptions { Acoustic, Tick, Lofi }
    public enum OpenHatOptions { Acoustic, House, Clubby }
    public enum SnareOptions { Acoustic, House, Lofi, FutureBass, Trap, Clubby }
}