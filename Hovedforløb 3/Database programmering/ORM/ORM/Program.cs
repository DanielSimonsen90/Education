using System;

namespace ORM
{
    class Program
    {
        static void Main()
        {
            Item item = new Item("Othello lagkage", 69, "Simon synes, den smager godt")
                .CreateTable()
                .Insert() as Item;

            Item another = new Item("N/A", 0, "N/A") { ID = 1 }.Select(0) as Item;

            another.Title = "Simons lagkage";
            another.Update();

            item.Delete();
            Console.ReadKey();
        }
    }
}
