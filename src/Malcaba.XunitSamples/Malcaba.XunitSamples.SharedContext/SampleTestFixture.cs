using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Malcaba.XunitSamples.SharedContext
{
    public class SampleTestFixture : IDisposable
    {
        public readonly Guid FixtureGuid;

        public SampleTestFixture()
        {
            FixtureGuid = Guid.NewGuid();
        }

        public void Dispose()
        {
        }
    }
}
