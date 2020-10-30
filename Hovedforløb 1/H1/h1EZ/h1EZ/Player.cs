using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace h1EZ
{
    class Player
    {
        public string Name { get; set; }
        public List<int> Highscore { get; set; }

        public int GetBestScore()
        {
            return Highscore.Min();
        }
    }
}
