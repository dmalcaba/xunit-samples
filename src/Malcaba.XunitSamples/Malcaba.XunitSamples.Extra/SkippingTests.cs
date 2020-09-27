using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Malcaba.XunitSamples.Extra
{
    public class SkippingTests
    {

        [Fact(Skip = "The reason for skipping")]
        public void Skip1()
        { 
        
        }

        [Theory(Skip = "The reason for skipping")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Skip2(int a)
        {

        }

        [Theory]
        [InlineData(1, Skip = "The reason for skipping")]
        [InlineData(2)]
        [InlineData(3)]
        public void Skip3(int a)
        {
            Assert.IsType<int>(a);
        }
    }
}
