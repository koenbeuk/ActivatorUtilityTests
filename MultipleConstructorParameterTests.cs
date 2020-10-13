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
    public class MultipleConstructorParameterTests : TestsBase
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
        public void CreateInstance_NoArguments_UsesEmptyConstructor()
        {
            var subject = ActivatorUtilities.CreateInstance<Subject>(ServiceProvider);

            Assert.NotNull(subject);
            Assert.Null(subject.TransientService);
            Assert.Null(subject.Argument);
        }


        [Fact]
        public void CreateInstance_SingleArgument_UsesCorrectConstructor()
        {
            var argument = "hello";
            var subject = ActivatorUtilities.CreateInstance<Subject>(ServiceProvider, argument);

            Assert.NotNull(subject);
            Assert.Null(subject.TransientService);
            Assert.Equal(argument, subject.Argument);
        }

        [Fact]
        public void CreateInstance_ExplicitService_UsesCorrectConstructor()
        {
            var service = new TransientService();
            var subject = ActivatorUtilities.CreateInstance<Subject>(ServiceProvider, service);

            Assert.NotNull(subject);
            Assert.Equal(service, subject.TransientService);
            Assert.Null(subject.Argument);
        }


        [Fact]
        public void CreateInstance_ExplicitServiceAndArgument_UsesCorrectConstructor()
        {
            var service = new TransientService();
            var argument = "hello";
            var subject = ActivatorUtilities.CreateInstance<Subject>(ServiceProvider, service, argument);

            Assert.NotNull(subject);
            Assert.Equal(service, subject.TransientService);
            Assert.Equal(argument, subject.Argument);
        }
    }
}
