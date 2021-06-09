using System.Collections.Generic;

namespace pewpew.Characters
{
    public class Sprite
    {
        public List<char> this[int height] => Value[height] as List<char>;

        public List<List<char>> Value { get; }
        public int Height => Value.Count;
        public int Width => Value.LongestCharArr().Count;

        public Sprite(List<List<char>> value) => Value = value;
    }
}
