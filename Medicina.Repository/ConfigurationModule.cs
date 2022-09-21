using Medicina.Domain.Models.Repository;
using Medicina.Repository.Context;
using Medicina.Repository.Database;
using Medicina.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicina.Repository
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MedicinaContext>(c =>
            {
                c.UseSqlServer(connectionString);
            });
            services.AddScoped(typeof(Repository<>));
            

            return services;
        }
    }
}
