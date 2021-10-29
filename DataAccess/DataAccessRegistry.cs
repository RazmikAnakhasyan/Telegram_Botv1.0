using DataAccess.Entities;
using DataAccess.Repositaries.Interfaces;
using DataAccess.Repositaries.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DataAccessRegistry
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IConvertRepository, ConvertRepository>();
            services.AddScoped<IBestRatesRepository, BestRatesRepository>();
        }
        public static void RegisterDBContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DBModel>(_ => _.UseSqlServer(connectionString));
        }
    }
}