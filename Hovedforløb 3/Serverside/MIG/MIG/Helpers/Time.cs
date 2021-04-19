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
    }
}
