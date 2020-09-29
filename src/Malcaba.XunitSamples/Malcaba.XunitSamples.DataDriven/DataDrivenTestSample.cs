using System.Collections.Generic;
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

        [Theory]
        [MemberData(nameof(Data))]
        public void CanAddTheoryMemberDataProperty(int value1, int value2, int expected)
        {
            var calculator = new Calculator();

            var result = calculator.Add(value1, value2);

            Assert.Equal(expected, result);
        }

        /// <summary>
        /// https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/
        /// </summary>
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { 1, 2, 3 },
                new object[] { -4, -6, -10 },
                new object[] { -2, 2, 0 },
                new object[] { int.MinValue, -1, int.MaxValue },
            };

        [Theory]
        [MemberData(nameof(StronglyTypedData))]
        public void CanAddTheoryDataProperty(int value1, int value2, int expected)
        {
            var calculator = new Calculator();

            var result = calculator.Add(value1, value2);

            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Strongly-typed version
        /// https://andrewlock.net/creating-strongly-typed-xunit-theory-test-data-with-theorydata/
        /// </summary>
        public static TheoryData<int, int, int> StronglyTypedData =>
            new TheoryData<int, int, int>
                {
                    { 1, 2, 3 },
                    { -4, -6, -10 },
                    { -2, 2, 0 },
                    { int.MinValue, -1, int.MaxValue }
                };
    }

    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
