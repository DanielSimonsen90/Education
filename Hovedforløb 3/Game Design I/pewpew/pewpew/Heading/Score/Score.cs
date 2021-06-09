using pewpew.Characters;
using System;

namespace pewpew
{
    public class Score
    {
        public string Playername { get; }
        public int Value { get; protected set; } = 0;

        public Score(Player player)
        {
            Playername = player.Name;
        }

        public Score Add(int score)
        {
            Value += score;
            return this;
        }
        public Score Remove(int score)
        {
            Value -= score;
            return this;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
