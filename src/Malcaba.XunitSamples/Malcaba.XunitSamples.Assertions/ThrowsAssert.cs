using System;
using Xunit;

namespace Malcaba.XunitSamples.Assertions
{
    public class ThrowsAssert
    {
        [Fact]
        public void AssertThrowsExample()
        {
            var dividend = 4;
            var divisor = 0;

            // you may capture the exception like this while asserting
            // assert expects exact match and not derived
            var ex = Assert.Throws<DivideByZeroException>(() => dividend / divisor);

            // so you can also assert message returned
            Assert.Equal("Attempted to divide by zero.", ex.Message);
        }

        [Fact]
        public void AssertThrowsAnyExample()
        {
            var dividend = 4;
            var divisor = 0;

            // if you want to just assert derived exceptions
            Assert.ThrowsAny<Exception>(() => dividend / divisor);
        }

    }

    
}
