using CrossCutting;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            NativeInjectorBoostStrapper.RegisterServices(services);
        }
    }
}
