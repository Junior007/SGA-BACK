
using Entregas.Application.Interfaces;
using Entregas.Application.Service;
using Entregas.Data.Context;
using Entregas.Data.Interface;
using Entregas.Data.Repository;


using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Entregas.Infraestructura.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {

            /////Data
            services.AddTransient<IEntregasRepository, EntregasRepository>();
            services.AddTransient<EntregasDBContext>();
            /////Application services
            services.AddTransient<IEntregasService, EntregasServices>();

        }
    }
}
