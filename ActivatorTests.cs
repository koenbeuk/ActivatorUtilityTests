using ActivatorUtilityTests.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Xunit;

namespace ActivatorUtilityTests
{
    public class ActivatorTests : TestsBase
    {
        public class MyController
        {
            public MyController(TransientService service)
            {
                Service = service;
            }

            public TransientService Service { get; }
        }

        [Fact]
        public void CreateInstance_MyControllerTypeWithExplicitService_Works()
        {
            var controllerType = typeof(MyController); // Imagine we don't know this at compile time

            var controller = Activator.CreateInstance(controllerType, ServiceProvider.GetService<TransientService>());

            Assert.NotNull(controller);
            Assert.IsType<MyController>(controller);
            Assert.NotNull(((MyController)controller).Service);
        }

        [Fact]
        public void CreateInstanceManually_MyControllerTypeWithExplicitService_Works()
        {
            var controllerType = typeof(MyController); // Imagine we don't know this at compile time

            var controller = controllerType
                .GetConstructor(new[] { typeof(TransientService) })
                .Invoke(new[] { ServiceProvider.GetService<TransientService>() });

            Assert.NotNull(controller);
            Assert.IsType<MyController>(controller);
            Assert.NotNull(((MyController)controller).Service);
        }

        [Fact]
        public void CreateInstanceManually_UnknownControllerTypeWithExplicitService_Works()
        {
            var controllerType = typeof(MyController); // Imagine we don't know this at compile time

            var constructor = controllerType.GetConstructors().First();
            var controller = constructor.Invoke(
                    constructor.GetParameters()
                        .Select(parameter => ServiceProvider.GetService(parameter.ParameterType))
                        .ToArray()
                    );

            Assert.NotNull(controller);
            Assert.IsType<MyController>(controller);
            Assert.NotNull(((MyController)controller).Service);
        }
    }
}
