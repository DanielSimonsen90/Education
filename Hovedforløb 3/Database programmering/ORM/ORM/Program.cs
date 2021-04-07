using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Literal_ORM;

namespace ORM
{
    class Program
    {
        static void Main()
        {
            Item item = new Item("Othello lagkage", 69, "Simon synes, den smager godt");
            item.Insert();

            item.Title = "Simons lagkage";
            item.Update();

            item.Delete();
            Console.ReadKey();
        }
    }
}
