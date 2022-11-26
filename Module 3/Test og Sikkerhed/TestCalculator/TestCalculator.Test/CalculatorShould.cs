using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCalculator
{
    class CalculatorShould : ICalculatorShould
    {
        public int Addition()
        {
            throw new NotImplementedException();
        }
        public int Subtraction()
        {
            throw new NotImplementedException();
        }

        public bool AND()
        {
            throw new NotImplementedException();
        }

        public bool OR()
        {
            throw new NotImplementedException();
        }

        public double[] QuadEquation()
        {
            throw new NotImplementedException();
        }
    }

    interface ICalculatorShould
    {
        int Addition();
        int Subtraction();
        bool AND();
        bool OR();
        double[] QuadEquation();
    }
}
