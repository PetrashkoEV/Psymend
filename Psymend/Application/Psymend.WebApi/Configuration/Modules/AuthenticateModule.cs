using Microsoft.Extensions.DependencyInjection;
using Psymend.WebApi.Authenticate;

namespace Psymend.WebApi.Configuration.Modules
{
    public static class AuthenticateModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
        }
    }
}