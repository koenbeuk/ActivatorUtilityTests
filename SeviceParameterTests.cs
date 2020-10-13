using System;
using ActivatorUtilityTests.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ActivatorUtilityTests
{
    public class ServiceParameterTests : TestsBase
    {
        public class Subject 
        {
            public Subject(TransientService service)
            {
                Service = service;
            }

            public TransientService Service { get; }
        }

        [Fact]
        public void CreateInstance_NoParameters_ReturnsInstance()
        {
            var subject = ActivatorUtilities.CreateInstance<Subject>(ServiceProvider);

            Assert.NotNull(subject);
            Assert.NotNull(subject.Service);
        }

        [Fact]
        public void CreateInstance_ExplicitParameters_ReturnsInstance()
        {
            var service = new TransientService();
            var subject = ActivatorUtilities.CreateInstance<Subject>(ServiceProvider, service);

            Assert.NotNull(subject);
            Assert.NotNull(subject.Service);
            Assert.Equal(service, subject.Service);
        }
    }
}
