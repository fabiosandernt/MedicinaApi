using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicina.Application.Exame.Service;

namespace Medicina.Application
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Application.ConfigurationModule).Assembly);

            services.AddMediatR(typeof(Application.ConfigurationModule).Assembly);

            services.AddScoped<IAsoService, AsoService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }
    }
}
