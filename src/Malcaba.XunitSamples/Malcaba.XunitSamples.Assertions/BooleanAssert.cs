using System;
using Xunit;

namespace Malcaba.XunitSamples.Assertions
{
    public class BooleanAssert
    {
        [Fact]
        public void IsEvenTest1()
        {
            var oddEven = new OddEven();

            var result = oddEven.IsEven(46);

            Assert.True(result);
        }

        [Fact]
        public void IsEvenTest2()
        {
            var oddEven = new OddEven();

            var result = oddEven.IsEven(11);

            Assert.False(result);
        }
    }

    public class OddEven
    {
        public bool IsEven(int value)
        {
            return value % 2 == 0;
        }
    }
}
