using System;
using ActivatorUtilityTests.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ActivatorUtilityTests
{
    public class ArgumentParameterTests : TestsBase
    {
        public class Subject 
        {
            public Subject(string argument)
            {
                Argument = argument;
            }

            public string Argument { get; }
        }

        
        [Fact]
        public void CreateInstance_WithArgument_ReturnsInstance()
        {
            var argument = "Hello";
            var subject = ActivatorUtilities.CreateInstance<Subject>(ServiceProvider, argument);

            Assert.NotNull(subject);
            Assert.NotNull(subject.Argument);
            Assert.Equal(argument, subject.Argument);
        }
    }
}
