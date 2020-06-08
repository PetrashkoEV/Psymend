using Microsoft.Extensions.DependencyInjection;
using Psymend.Infrastructure.Configuration.Provider;
using Psymend.Infrastructure.Core.Configuration;
using Psymend.Infrastructure.Core.Repositories;
using Psymend.Infrastructure.Repositories;

namespace Psymend.Infrastructure.Configuration
{
    public static class InfrastructureModule
    {
        public static void RegisterModules(IServiceCollection services)
        {
            services.AddSingleton<ISqlConnectionStringProvider, SqlConnectionStringProvider>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ILusherTestRepository, LusherTestRepository>();
            services.AddTransient<ILusherInterpretationRepository, LusherInterpretationRepository>();
            services.AddTransient<ITestRepository, TestRepository>();
        }
    }
}