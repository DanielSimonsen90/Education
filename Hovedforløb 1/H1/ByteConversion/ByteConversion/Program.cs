using System;
using System.Text;

namespace ByteConversion
{
    class Program
    {
        static void Main()
        {
            //Hejsa
            //Convert(new byte[] { 72, 101, 106, 115, 97, 36, 0, 0, 0, 0, 0, 22, 66 });
            while (true)
                Convert(RandomizeBytes());
        }

        static byte[] RandomizeBytes()
        {
            Random rand = new Random();
            int Max = new Random().Next(5, 25);
            var bytes = new byte[Max];
            for (int x = 0; x < Max; x++)
                bytes[x] = ((byte)Randomize(rand));
            return bytes;
        }
        static int Randomize(Random rand)
        {
            var result = rand.Next(65, 91);
            if (result > 57 && result < 65)
                Randomize(rand);
            return result;
        }
        static void Convert(byte[] bytes)
        {
            string str = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
            int Num = BitConverter.ToInt32(bytes, 0);
            double deci = BitConverter.ToSingle(bytes, 0);

            Console.Write("Started with: ");
            for (int x = 0; x < bytes.Length; x++)
                Console.Write($"{bytes[x]}, ");
            Console.WriteLine();
            Console.WriteLine($"As string: {str}");
            Console.WriteLine($"As int: {Num}");
            Console.WriteLine($"As double: {Math.Round(deci, 2)}");
            Console.ReadKey();
            Console.Clear();
        }
    }
}