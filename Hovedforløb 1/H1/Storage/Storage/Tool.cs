using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    class Tool : Item
    {
        public Tool(string Name, int Amount, List<Item> Storage) : base(Name, Amount, Storage)
        {

        }
    }
}
