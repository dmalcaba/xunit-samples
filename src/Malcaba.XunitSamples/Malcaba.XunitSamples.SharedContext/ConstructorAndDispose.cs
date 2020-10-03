using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Malcaba.XunitSamples.SharedContext
{
    public class StackTests : IDisposable
    {
        readonly Stack<int> _stack;
        private readonly ITestOutputHelper _output;

        public StackTests(ITestOutputHelper output)
        {
            _stack = new Stack<int>();
            _output = output;

            _output.WriteLine("From test constructor.");
        }

        public void Dispose()
        {
            _output.WriteLine("From test dispose.");
        }

        [Fact]
        public void WithNoItems_CountShouldReturnZero()
        {
            _output.WriteLine(nameof(WithNoItems_CountShouldReturnZero));
            var count = _stack.Count;

            Assert.Equal(0, count);
        }

        [Fact]
        public void AfterPushingItem_CountShouldReturnOne()
        {
            _output.WriteLine(nameof(AfterPushingItem_CountShouldReturnOne));

            _stack.Push(42);

            var count = _stack.Count;

            Assert.Equal(1, count);
        }
    }
}
