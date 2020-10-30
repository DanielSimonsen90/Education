using System;

namespace Lommeregner_H1
{
    class Program
    {
        static double Plus(double result, double num)
        {
            return result + num;       
        }
        public static double Minus(double result, double num)
        {
            return result - num;
        }
        static double Multi(double result, double num)
        {
            return result * num;
        }
        static double Divide(double result, double num)
        {
            return result / num;
        }
        
        static void Main()
        { 
            /// <param name="count"> Used to count amount of numbers entered, incrimenting by 1 every number. </param>
            int count = 1;
            Console.Write($"Number {count++}: ");
            //Total sum, the calculation, the result
            double result = Convert.ToDouble(Console.ReadLine());

            while (true)
            {
                Console.Write("Operator type: ");
                //Write the operator type being either plus, minus, divide or multiplication
                string OpType = Console.ReadLine();

                //If a valid operator type isn't used, calculate all numbers entered
                if (OpType != "+" && OpType != "-" && OpType != "*" && OpType != "/")
                {
                    Console.WriteLine($"Your result is {result}");
                    Console.ReadKey();
                    return;
                }

                Console.Write($"Number {count++}: ");
                double num = Convert.ToDouble(Console.ReadLine());

                //maths all depending on which operator type you pick
                switch (OpType)
                {
                    case "+":
                        result = Plus(result, num);
                        break;
                    case "-":
                        result = Minus(result, num);
                        break;
                    case "*":
                        result = Multi(result, num);
                        break;
                    case "/":
                        result = Divide(result, num);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
