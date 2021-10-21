using CodeFirst.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RepositoryRegistry
    {
        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
        }
        public static void RegisterDbContext(IServiceCollection services,string conenctionString)
        {
            services.AddDbContext<DBModel>(_ => _.UseSqlServer(conenctionString));
        }
    }
}
