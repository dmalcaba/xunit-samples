using System;
using System.Runtime.InteropServices;
using Xunit;

namespace Malcaba.XunitSamples.Extra
{
    /// <summary>
    /// https://josephwoodward.co.uk/2019/01/skipping-xunit-tests-based-on-runtime-conditions
    /// </summary>
    public class SkipTestBasedOnRuntimeConditions
    {
        [IgnoreOnAppVeyorLinuxFact]
        public void MyTest()
        { 
        }

    }

    /// <summary>
    /// Extend the FactAttribute class and set the Skip Property if condition is met
    /// </summary>
    public sealed class IgnoreOnAppVeyorLinuxFact : FactAttribute
    {
        public IgnoreOnAppVeyorLinuxFact()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && IsAppVeyor())
            {
                Skip = "Ignore on Linux when run via AppVeyor";
            }
        }

        private static bool IsAppVeyor()
            => Environment.GetEnvironmentVariable("APPVEYOR") != null;
    }
}
