
using Entregas.Application.Interfaces;
using Entregas.Application.Service;
using Entregas.Data.Context;
using Entregas.Data.Repository;
using Entregas.Domain.Interfaces;

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
            services.AddTransient<IAlmacenesService, AlmacenesService>();
            services.AddTransient<IItemsService, ItemsService>();

        }
    }
}
