using System;
using Xunit;
using Xunit.Abstractions;

namespace Malcaba.XunitSamples.Extra
{
    public class CapturingOutput
    {
        private readonly ITestOutputHelper _output;

        public CapturingOutput(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1()
        {
            _output.WriteLine("Output from Test1");
        }
    }
}
