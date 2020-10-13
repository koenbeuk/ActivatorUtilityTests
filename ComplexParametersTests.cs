using System;
using ActivatorUtilityTests.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ActivatorUtilityTests
{
    public class ComplexParametersTests : TestsBase
    {
        public class Subject 
        {
            public Subject(string argument1, TransientService service1, string argument2, SingletonService service2)
            {
                Argument1 = argument1;
                Service1 = service1;
                Argument2 = argument2;
                Service2 = service2;
            }

            public string Argument1 { get; }
            public TransientService Service1 { get; }
            public string Argument2 { get; }
            public SingletonService Service2 { get; }
        }


        [Fact]
        public void CreateInstance_ExplicitParameters_ReturnsInstance()
        {
            var service1 = new TransientService();
            var service2 = new SingletonService();
            var argument1 = "Hello";
            var argument2 = "Hello";

            var subject = ActivatorUtilities.CreateInstance<Subject>(ServiceProvider, service1, service2, argument1, argument2);

            Assert.NotNull(subject);
            Assert.Equal(service1, subject.Service1);
            Assert.Equal(service2, subject.Service2);
            Assert.Equal(argument1, subject.Argument1);
            Assert.Equal(argument2, subject.Argument2);
        }

        [Fact]
        public void CreateInstance_ExplicitParametersReversed_ReturnsInstance()
        {
            var service1 = new TransientService();
            var service2 = new SingletonService();
            var argument1 = "Hello";
            var argument2 = "Hello";

            var subject = ActivatorUtilities.CreateInstance<Subject>(ServiceProvider, argument1, argument2, service1, service2);

            Assert.NotNull(subject);
            Assert.Equal(service1, subject.Service1);
            Assert.Equal(service2, subject.Service2);
            Assert.Equal(argument1, subject.Argument1);
            Assert.Equal(argument2, subject.Argument2);
        }

        [Fact]
        public void CreateInstance_ExplicitParametersMixed_ReturnsInstance()
        {
            var service1 = new TransientService();
            var service2 = new SingletonService();
            var argument1 = "Hello";
            var argument2 = "Hello";

            var subject = ActivatorUtilities.CreateInstance<Subject>(ServiceProvider, service1, argument1, service2, argument2);

            Assert.NotNull(subject);
            Assert.Equal(service1, subject.Service1);
            Assert.Equal(service2, subject.Service2);
            Assert.Equal(argument1, subject.Argument1);
            Assert.Equal(argument2, subject.Argument2);
        }

        [Fact]
        public void CreateInstance_ImplicitParameters_ReturnsInstance()
        {
            var argument1 = "Hello";
            var argument2 = "Hello";

            var subject = ActivatorUtilities.CreateInstance<Subject>(ServiceProvider, argument1, argument2);

            Assert.NotNull(subject);
            Assert.NotNull(subject.Service1);
            Assert.NotNull(subject.Service2);
            Assert.Equal(argument1, subject.Argument1);
            Assert.Equal(argument2, subject.Argument2);
        }
    }
}
