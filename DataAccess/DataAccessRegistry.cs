
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.Repositories;
using DataAccess.Models;

namespace DataAccess
{
    public static class DataAccessRegistry
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IBestAvailableRateRepository, BestAvailableRateRepository>(); 
        }
        public static void RegisterDBContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DBModel>(_ => _.UseSqlServer(connectionString));
        }
    }
}