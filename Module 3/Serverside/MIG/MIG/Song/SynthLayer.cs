using DanhoLibrary;
using DanhoLibrary.Extensions;

namespace MIG.Song
{
    public class SynthLayer
    {
        public WaveTypes Wave { get; set; } = new WaveTypes[] { WaveTypes.Sine, WaveTypes.Saw, WaveTypes.Square, WaveTypes.Triangle }.GetRandomItem();
        public int Voices { get; } = ConsoleItems.RandomNumber(8);
        public bool Detuned { get; }

        public SynthLayer()
        {
            Detuned = ConsoleItems.RandomNumber(2) == 1 && Voices > 1;
        }
    }
    public enum WaveTypes { Sine, Saw, Square, Triangle }

}