using ActivatorUtilityTests.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ActivatorUtilityTests
{
    public class PreferredConstructorTests : TestsBase
    {
        public class Subject
        { 
            public Subject()
            {

            }

            public Subject(string argument)
            {
                Argument = argument;
            }

            [ActivatorUtilitiesConstructor]
            public Subject(TransientService transientService)
            {
                TransientService = transientService;
            }

            public Subject(string argument, TransientService transientService)
            {
                Argument = argument;
                TransientService = transientService;
            }

            public string Argument { get; }
            public TransientService TransientService { get; }
        }

        [Fact]
        public void CreateInstance_NoArguments_UsesPreferredConstructor()
        {
            var subject = ActivatorUtilities.CreateInstance<Subject>(ServiceProvider);

            Assert.NotNull(subject);
            Assert.NotNull(subject.TransientService);
            Assert.Null(subject.Argument);
        }
    }
}
