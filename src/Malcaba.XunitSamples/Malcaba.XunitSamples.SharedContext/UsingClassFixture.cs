using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Malcaba.XunitSamples.SharedContext
{
    public class UsingClassFixture : IClassFixture<SampleTestFixture>
    {
        private readonly SampleTestFixture _fixture;
        private readonly ITestOutputHelper _output;

        public UsingClassFixture(SampleTestFixture fixture, ITestOutputHelper output)
        {
            _fixture = fixture;
            _output = output;
            _output.WriteLine("From Test Class constructor");
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 3, 5)]
        [InlineData(3, 5, 8)]
        public void AddTest(int a, int b, int expected)
        {
            _output.WriteLine("Theory Test");
            _output.WriteLine(_fixture.FixtureGuid.ToString());
            var calculator = new Calculator();
            var actual = calculator.Add(a, b);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddTestFact()
        {
            _output.WriteLine("Fact Test");
            _output.WriteLine(_fixture.FixtureGuid.ToString());
            var calculator = new Calculator();
            var actual = calculator.Add(1, 2);

            Assert.Equal(3, actual);
        }

        public class Calculator
        {
            public int Add(int a, int b)
            {
                return a + b;
            }
        }
    }
}
