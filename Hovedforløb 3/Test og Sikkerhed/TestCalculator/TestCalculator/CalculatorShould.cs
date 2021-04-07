using Xunit;

namespace TestCalculator
{
    public class CalculatorShould : ICalculatorShould
    {
        private readonly Calculator calc = new Calculator();

        [Fact]
        public void Addition()
        {
            Assert.Equal(4, calc.Addition(2, 2));
            Assert.Equal(21, calc.Addition(9, 10)); //Happy birthday, Spag
        }
        [Fact]
        public void Subtraction()
        {
            Assert.Equal(3, calc.Subtraction(4, 1)); //Quick mafs
        }

        [Fact]
        public void AND()
        {
            Assert.True(calc.AND(true, true));
            Assert.True(calc.AND(false, false));
            Assert.False(calc.AND(true, true));
            Assert.False(calc.AND(false, false));
        }
        [Fact]
        public void OR()
        {
            Assert.True(calc.OR(true, true));
            Assert.True(calc.OR(false, false));
            Assert.False(calc.OR(true, true));
            Assert.False(calc.OR(false, false));
        }

        [Fact]
        public void QuadEquation()
        {

        }
    }

    interface ICalculatorShould
    {
        void Addition();
        void Subtraction();
        void AND();
        void OR();
        void QuadEquation();
    }
}
