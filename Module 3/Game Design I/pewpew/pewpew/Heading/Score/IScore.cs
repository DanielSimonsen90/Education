using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pewpew
{
    public interface IScore
    {
        public string Playername { get; }
        public int Value { get; protected set; }

        IScore Add(int score);
        IScore Remove(int score);
    }
}
