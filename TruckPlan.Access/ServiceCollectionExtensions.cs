using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckPlan.IAccess;

namespace TruckPlan.Access
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAccess(this IServiceCollection services)
        {
            services.AddScoped<IJourneyAccess, JourneyAccess>();
            services.AddScoped<ITruckDriverAccess, TruckDriverAccess>();
            services.AddScoped<ITruckGPSAccess, TruckGPSAccess>();
            services.AddScoped<ITruckAccess, TruckAccess>();
            services.AddScoped<IJourneySummaryAccess, JourneySummaryAccess>();

            return services;
        }
    }
}
