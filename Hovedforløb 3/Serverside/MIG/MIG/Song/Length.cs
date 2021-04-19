using MIG.Helpers;

namespace MIG.Song
{
    public class Length
    {
        /// <summary>
        /// In seconds
        /// </summary>
        public int Value { get; set; }
        public string ValueAsString => ToString();

        public Length(int valueInSeconds) => Value = valueInSeconds;

        public override string ToString()
        {
            int value = Value;
            int seconds = Time.Reduce(ref value, Time.Second);
            int minutes = Time.Reduce(ref value, Time.Minute);
            int hours = Time.Reduce(ref value, Time.Hour);

            int[] times = { hours, minutes, seconds };
            string result = string.Empty;

            foreach (int number in times)
            {
                if (number < 0) continue;
                result += number < 10 ? $"0{number}" : number.ToString();
                result += ".";
            }

            return result[0..^1];
        }
    }
}
