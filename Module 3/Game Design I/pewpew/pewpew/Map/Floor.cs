using pewpew.Characters;
using System.Collections.Generic;
using System.Text;

namespace pewpew
{
    public class Floor : IPositionMe
    {
        public Sprite Sprite { get; }

        public Floor(int width)
        {
            Sprite = new Sprite(new List<List<char>>()
            {
                new List<char>().AddFor('_', width)
            });
        }
    }
}
