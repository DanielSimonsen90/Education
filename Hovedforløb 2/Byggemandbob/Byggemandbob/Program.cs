using System;
using System.Collections.Generic;
using DanhoLibrary;

namespace Byggemandbob
{
    class Program
    {
        static void Main(string[] args)
        {
            Toolbox bigboibox = new Toolbox(new Tool("Screwdriver"));
            Tool Saw = new Tool("Saw"), 
                Hammer = new Tool("Hammer");
            bigboibox += Saw;
            bigboibox += Hammer;
            bigboibox -= Saw;
            Toolbox smolboibox = Hammer + Saw;
            Display(bigboibox, smolboibox);
        }

        private static void Display(Toolbox bigboibox, Toolbox smolboibox)
        {
            bigboibox.Consists(nameof(bigboibox));
            smolboibox.Consists(nameof(smolboibox));
            Console.ReadKey();
        }
    }

    class Toolbox
    {
        private readonly List<Tool> Tools = new List<Tool>();
        
        public Tool this[string toolName] => Tools.Find(t => t.Name == toolName);
        public static Toolbox operator +(Toolbox box, Tool item)
        {
            box.Tools.Add(item);
            return box;
        }
        public static Toolbox operator -(Toolbox box, Tool item)
        {
            if (box.Tools.Contains(item))
                box.Tools.Remove(item);
            return box;
        }

        public Toolbox(params Tool[] tools) => Tools.AddRange(tools);
        public void Consists(string name) => Console.WriteLine($"{name} consists of {ToString()}");
        public override string ToString() => Tools.ToBigBoiString(true);
    }
    class Tool
    {
        public string Name { get; set; }

        public static Toolbox operator +(Tool a, Tool b) => new Toolbox(a, b);

        public Tool(string name) => Name = name;
        public override string ToString() => Name;
    }
}
