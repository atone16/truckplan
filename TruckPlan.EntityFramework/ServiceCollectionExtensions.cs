using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckPlan.EntityFramework
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDBContext>(options => 
                options.UseSqlServer("Server=localhost;Database=TruckPlan;User Id=sa;Password=AycA7gR9qwESrm;TrustServerCertificate=True;"));
            return services;
        }
    }
}
