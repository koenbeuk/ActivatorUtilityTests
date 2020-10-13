using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ActivatorUtilityTests
{
    public class MultipleArgumentParameterTests : TestsBase
    {
        public class Subject
        {
            public Subject(string argument1, int argument2)
            {
                Argument1 = argument1;
                Argument2 = argument2;
            }

            public string Argument1 { get; }
            public int Argument2 { get; }
        }


        [Fact]
        public void CreateInstance_WithArguments_ReturnsInstance()
        {
            var argument1 = "Hello";
            var argument2 = 42;
            var subject = ActivatorUtilities.CreateInstance<Subject>(ServiceProvider, argument1, argument2);

            Assert.NotNull(subject);
            Assert.Equal(argument1, subject.Argument1);
            Assert.Equal(argument2, subject.Argument2);
        }

        [Fact]
        public void CreateInstance_WithArgumentsReversed_ReturnsInstance()
        {
            var argument1 = "Hello";
            var argument2 = 42;
            var subject = ActivatorUtilities.CreateInstance<Subject>(ServiceProvider, argument2, argument1);

            Assert.NotNull(subject);
            Assert.Equal(argument1, subject.Argument1);
            Assert.Equal(argument2, subject.Argument2);
        }
    }
}
