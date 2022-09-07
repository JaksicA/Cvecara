using Cvecara.Business.Managers;
using Cvecara.Business.Managers.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvecara.Business
{
    public static class BusinessStartup
    {
        public static IServiceCollection RegisterBusinessDependencies(this IServiceCollection services)
        {
            services.AddScoped<IItemManager, ItemManager>();

            return services;
        }
    }
}
