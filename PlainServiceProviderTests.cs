using ActivatorUtilityTests.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ActivatorUtilityTests
{
    public class PlainServiceProviderTests
    {
        public void GetService_DependencyInContainer_ReturnsDependency()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<Services.TransientService>()
                .BuildServiceProvider();

            var service = serviceProvider.GetService<TransientService>();

            Assert.NotNull(service);
        }
    }
}
