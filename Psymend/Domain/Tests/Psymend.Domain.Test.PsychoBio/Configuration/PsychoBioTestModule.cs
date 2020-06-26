using Microsoft.Extensions.DependencyInjection;
using Psymend.Domain.Test.PsychoBio.Core.Processor;
using Psymend.Domain.Test.PsychoBio.Processor;

namespace Psymend.Domain.Test.PsychoBio.Configuration
{
    public static class PsychoBioTestModule
    {
        public static void RegisterModules(IServiceCollection services)
        {
            services.AddTransient<IPsychoBioTestProcessor, PsychoBioTestProcessor>();
        }
    }
}