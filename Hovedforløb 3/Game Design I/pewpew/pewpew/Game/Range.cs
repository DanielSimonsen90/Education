using System;

namespace pewpew
{
    public class Range
    {
        public int Minimum { get; }
        public int Maximum { get; }

        public int Value => new Random().Next(Minimum, Maximum);

        public Range(int min, int max)
        {
            Minimum = min;
            Maximum = max;
        }
    }
}
