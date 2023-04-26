using Xunit;

namespace Computation.UnitTests
{
    public class CalculatorTests
    {
        [Fact]
        public void SumNumbers_StartAt100SumNext1_TotalIs100()
        {
            var calculator = new Calculator();

            var actual = calculator.SumNumbers(100, 1);

            Assert.Equal(100, actual);
        }
        [Fact]
        public void SumNumbers_StartAt100SumNext2_TotalIs201()
        {
            var calculator = new Calculator();

            var actual = calculator.SumNumbers(100, 2);

            Assert.Equal(201, actual);
        }
        [Fact]
        public void SumNumbers_StartAt100SumNext0_TotalIs0()
        {
            var calculator = new Calculator();

            var actual = calculator.SumNumbers(100, 0);

            Assert.Equal(0, actual);
        }
        [Fact]
        public void SumNumbers_StartAt0SumNext0_TotalIs0()
        {
            var calculator = new Calculator();

            var actual = calculator.SumNumbers(0, 0);

            Assert.Equal(0, actual);
        }
        [Fact]
        public void SumNumbers_StartAt0SumNext3_TotalIs3()
        {
            var calculator = new Calculator();

            var actual = calculator.SumNumbers(0, 3);

            Assert.Equal(3, actual);
        }
        [Fact]
        public void SumNumbers_StartAt0SumNext100TotalIs4950()
        {
            var calculator = new Calculator();

            var actual = calculator.SumNumbers(0, 100);

            Assert.Equal(4950, actual);
        }
    }
}
