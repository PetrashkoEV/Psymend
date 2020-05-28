using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Psymend.WebApi.Configuration.Model;

namespace Psymend.WebApi.Configuration.Modules
{
    public static class ConfigurationModule
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthenticateConfigurationModel>(options => configuration.GetSection("AuthenticateConfiguration").Bind(options));
        }
    }
}