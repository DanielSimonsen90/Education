using pewpew.Characters;

namespace pewpew
{
    public class Heading : IHeading
    {
        public Stats Stats { get; }
        public Score Score { get; }

        public Heading(Player player)
        {
            Stats = new Stats(player);
            Score = new Score(player);
        }
    }
}
