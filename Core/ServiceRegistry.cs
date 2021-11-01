using DataAccess.Repository;
using Core.Services.Interfaces;
using Core.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Services;

namespace Core.Services
{
    public class ServiceRegistry
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICurrencyService, CurrrencyService>();
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<ICurrencies, Currencies>();
            services.AddScoped<IBestRates, BestRates>();
            services.AddScoped<IBestAvailableRateService, BestAvailableRateService>();
 
        }
  
    }
}
