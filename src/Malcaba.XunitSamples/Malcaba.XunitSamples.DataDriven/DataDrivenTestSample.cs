using System;
using Xunit;

namespace Malcaba.XunitSamples.DataDriven
{
    public class DataDrivenTestSample
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 3, 5)]
        [InlineData(3, 5, 8)]
        public void AddTest(int a, int b, int expected)
        {
            var calculator = new Calculator();
            var actual = calculator.Add(a, b);

            Assert.Equal(expected, actual);
        }
    }

    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
