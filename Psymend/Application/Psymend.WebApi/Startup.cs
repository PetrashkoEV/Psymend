using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Psymend.WebApi.Authenticate;
using Psymend.WebApi.Configuration;
using Psymend.WebApi.Configuration.Model;
using Psymend.WebApi.Configuration.Modules;

namespace Psymend.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var authConfigModel = Configuration.GetSection("AuthenticateConfiguration").Get<AuthenticateConfigurationModel>();
            services.AddJwtBearerTokenAuthentication(authConfigModel.Secret);

            // register DI
            PsymendContainerFactory.RegisterModules(services);

            ConfigurationModule.Register(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
