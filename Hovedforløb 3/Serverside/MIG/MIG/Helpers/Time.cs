using DanhoLibrary.Extensions;
using System.Linq;
using System.Text.RegularExpressions;

namespace MIG.Helpers
{
    public static class Time
    {
        public static int Second => 1;
        public static int Minute => Second * 60;
        public static int Hour => Minute * 60;

        public static int ToMinutes(int seconds) => int.Parse((seconds / 60).ToString());
        public static int ToHours(int minutes) => int.Parse((minutes / 60).ToString());

        public static int Reduce(ref int value, int timeInSeconds)
        {
            int result = 0;

            while (value > timeInSeconds)
            {
                value -= timeInSeconds;
                result++;
            }
            return result;
        }
        public static int ToSeconds(string value)
        {
            //Split value by . or s, m, h (anything that isn't a number)
            string[] timesAsStrings = value.Contains('.') ? value.Split('.') : Regex.Split(value, "/![0-9]/g"); //Split value from everything that isn't a number

            //Convert string times as ints and reverse array from [hour, minute, second] => [second, minute, hour]
            int[] times = timesAsStrings.Map(v => int.Parse(v)).Reverse() as int[];
            int[] timeDefinitions = new int[] { Second, Minute, Hour };

            int valueInSeconds = 0;
            for (int i = 0; i < times.Length; i++)
                valueInSeconds += times[i] * timeDefinitions[i];
            return valueInSeconds;
        }
    }
}
