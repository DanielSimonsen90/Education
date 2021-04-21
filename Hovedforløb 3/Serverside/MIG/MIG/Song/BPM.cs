using DanhoLibrary;
namespace MIG.Song
{
    public class BPM
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int Value { get; set; } = -1;

        public BPM(int min, int max)
        {
            Min = min;
            Max = max;
        }
        private BPM(int min, int max, int value) : this(min, max)
        {
            if (!(min <= value && value <= max))
                throw new InvalidBPMValueException($"Value \"{value}\" is not between range {GetRange()}");
            Value = value;
        }

        public BPM RandomValue() => new(Min, Max, ConsoleItems.RandomNumber(Min, Max));
        public BPM SetValue(int value) => new(Min, Max, value);
        private string GetRange() => $"{Min} - {Max}";

        public override string ToString() => Value == -1 ? $"Range: {GetRange()}" : Value.ToString();
    }
}
