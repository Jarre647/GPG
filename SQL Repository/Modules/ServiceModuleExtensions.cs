using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SQL_Repository.Models;
using SQL_Repository.Services;
using SQL_Repository.Services.Contracts;

namespace SQL_Repository.Modules
{
    public static class ServiceModuleExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IGrudgesApi, GrudgeApi>();
        }
    }
}
