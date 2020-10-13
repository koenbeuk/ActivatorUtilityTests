using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivatorUtilityTests.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ActivatorUtilityTests
{
    public abstract class TestsBase
    {
        protected IServiceProvider ServiceProvider = new ServiceCollection()
            .AddTransient<TransientService>()
            .AddScoped<ScopedService>()
            .AddSingleton<SingletonService>()
            .BuildServiceProvider();
            
    }
}
