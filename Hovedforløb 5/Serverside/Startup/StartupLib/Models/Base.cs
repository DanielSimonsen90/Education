using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupLib.Models
{
    public abstract class Base
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Ukendt";
    }
}
