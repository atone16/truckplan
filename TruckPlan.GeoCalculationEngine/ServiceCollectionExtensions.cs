using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckPlan.IGeoCalculationEngine;

namespace TruckPlan.GeoCalculationEngine
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCalculationEngine(this IServiceCollection services)
        {
            services.AddScoped<ICalculationEngine, GeoCalculationEngine>();

            return services;
        }
    }
}
