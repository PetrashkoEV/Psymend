using Microsoft.Extensions.DependencyInjection;
using Psymend.Domain.Core.Services;
using Psymend.Domain.Services;

namespace Psymend.Domain.Configuration
{
    public static class DomainModule
    {
        public static void RegisterModules(IServiceCollection services)
        {
            services.AddTransient<IAuthenticateService, AuthenticateService>();
        }
    }
}