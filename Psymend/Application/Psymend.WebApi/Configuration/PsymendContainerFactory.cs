using Microsoft.Extensions.DependencyInjection;
using Psymend.WebApi.Configuration.Modules;

namespace Psymend.WebApi.Configuration
{
    public static class PsymendContainerFactory
    {
        public static void RegisterModules(IServiceCollection services)
        {
            AuthenticateModule.Register(services);
        }
    }
}