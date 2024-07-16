using Microsoft.Extensions.DependencyInjection;
using TruckPlan.IManagers;

namespace TruckPlan.Managers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddManagers(this IServiceCollection services)
        {
            services.AddScoped<ITruckDriverManager, TruckDriverManager>();
            services.AddScoped<ITruckManager, TruckManager>();
            services.AddScoped<IJourneyManager, JourneyManager>();

            return services;
        }
    }
}
