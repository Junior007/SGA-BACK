
using InventoryApplication.Interfaces;
using InventoryApplication.Service;
using InventoryData.Context;
using InventoryData.Repository;
using InventoryDomain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace InventoryDomain.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var assembly = assemblies.Where(ass => ass.FullName.Contains("InventoryDomain")).ToArray();
            services.AddMediatR(assembly);
            /////Data
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<InventoryDBContext>();
            /////Application services
            services.AddTransient<IAlmacenesService, AlmacenesService>();
            services.AddTransient<IItemsService, ItemsService>();

        }
    }
}
