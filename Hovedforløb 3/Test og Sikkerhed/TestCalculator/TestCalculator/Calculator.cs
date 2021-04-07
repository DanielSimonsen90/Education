using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCalculator
{
    class Calculator : ICalculatorRequirements
    {
        public int Addition(int num1, int num2) => num1 + num2;
        public int Subtraction(int num1, int num2) => num1 - num2;
        public bool AND(bool val1, bool val2) => val1 && val2;
        public bool OR(bool val1, bool val2) => val1 || val2;
        public double[] QuadEquation(int num1, int num2, int num3) => new QuadCalculation(num1, num2, num3).Root;
    }

    interface ICalculatorRequirements
    {
        int Addition(int num1, int num2);
        int Subtraction(int num1, int num2);
        bool AND(bool val1, bool val2);
        bool OR(bool val1, bool val2);
        double[] QuadEquation(int num1, int num2, int num3);
    }
}
