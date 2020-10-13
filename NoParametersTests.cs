using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ActivatorUtilityTests
{
    public class NoParameterTests : TestsBase
    {
        public class Subject 
        {
            public Subject()
            {
                // No  parameters
            }
        }

        [Fact]
        public void CreateInstance_NoParameters_ReturnsInstance()
        {
            var subject = ActivatorUtilities.CreateInstance<Subject>(ServiceProvider);

            Assert.NotNull(subject);
        }
    }
}
