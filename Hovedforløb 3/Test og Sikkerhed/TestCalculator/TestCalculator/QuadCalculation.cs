using System;

namespace TestCalculator
{
    class QuadCalculation
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public double Discriminant => B ^ 2 - 4 * A * C;
        public Top Top => new Top(
            -B / (2 * A),
            Discriminant / (4 * A)
        );
        public double[] Root => new double[]
        {
            CalculateCollision(true),
            CalculateCollision(false)
        };

        private double CalculateCollision(bool positive)
        {
            double dValue = Discriminant > 0 ? Math.Sqrt(Discriminant) : -1;
            double firstHalf = positive ? -B + dValue : -B - dValue;
            return firstHalf / (2 * A);
        }

        public QuadCalculation(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }
    }

    class Top
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Top(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
