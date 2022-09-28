using Cvecara.Data.Repositories;
using Cvecara.Data.Repositories.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvecara.Data
{
    public static class DataStartup
    {
        public static IServiceCollection RegisterDataProjectDependencies(this IServiceCollection services)
        {
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IArrangementRepository, ArrangementRepository>();
            services.AddScoped<IArrangementItemRepository, ArrangementItemRepository>();

            return services;
        }
    }
}
