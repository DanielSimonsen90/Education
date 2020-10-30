using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance
{
    class Distance
    {
        public Distance(double start, double end)
        {
            
        }
        public double Start { get; set; }
        public double End { get; set; }
        public double GetDistance()
        {
            return End - Start;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Start længde ");
            var Start = Convert.ToDouble(Console.ReadLine());
            Console.Write("Slut længde ");
            var End = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Længde: {new Distance(Start, End).GetDistance()}");
        }
    }
}
