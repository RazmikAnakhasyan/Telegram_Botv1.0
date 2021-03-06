using DataAccess.Models;
using DataAccess.Repositaries.Interfaces;
using DataAccess.Repositaries.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddDbContext<DbModel>(_ => _.UseSqlServer(connectionString));
        }
    }
}