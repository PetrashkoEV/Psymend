using Microsoft.Extensions.DependencyInjection;
using Psymend.Domain.Test.Lusher.Core.Services;
using Psymend.Domain.Test.Lusher.Services;

namespace Psymend.Domain.Test.Lusher.Configuration
{
    public static class TestLusherModule
    {
        public static void RegisterModules(IServiceCollection services)
        {
            services.AddTransient<ITestLusherProcessor, TestLusherProcessor>();
        }
    }
}