using System;
using ActivatorUtilityTests.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ActivatorUtilityTests
{
    public class ServiceAndArgumentParametersTests : TestsBase
    {
        public class Subject 
        {
            public Subject(TransientService service, string argument)
            {
                Service = service;
                Argument = argument;
            }

            public TransientService Service { get; }
            public string Argument { get; }
        }

        [Fact]
        public void CreateInstance_ImplicitService_ReturnsInstance()
        {
            var argument = "Hello";
            var subject = ActivatorUtilities.CreateInstance<Subject>(ServiceProvider, argument);

            Assert.NotNull(subject);
            Assert.NotNull(subject.Service);
            Assert.Equal(argument, subject.Argument);
        }

        [Fact]
        public void CreateInstance_ExplicitParameters_ReturnsInstance()
        {
            var service = new TransientService();
            var argument = "Hello";
            var subject = ActivatorUtilities.CreateInstance<Subject>(ServiceProvider, service, argument);

            Assert.NotNull(subject);
            Assert.NotNull(subject.Service);
            Assert.Equal(service, subject.Service);
            Assert.Equal(argument, subject.Argument);
        }

        [Fact]
        public void CreateInstance_ExplicitParametersReversed_ReturnsInstance()
        {
            var service = new TransientService();
            var argument = "Hello";
            var subject = ActivatorUtilities.CreateInstance<Subject>(ServiceProvider, argument, service);

            Assert.NotNull(subject);
            Assert.NotNull(subject.Service);
            Assert.Equal(service, subject.Service);
            Assert.Equal(argument, subject.Argument);
        }
    }
}
