using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckPlan.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCore(
            this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(TruckPlanMapperProfile));
            return services;
        }
    }
}
