using Core.Services.Interfaces;
using Core.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using Core.Services;


namespace Core
{
    public class ServiceRegistry
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICurrencies, Currencies>();
            services.AddScoped<IBestRates, BestRates>();
            services.AddScoped<IBestAvailableRateService, BestAvailableRateService>();
 
        }
  
    }
}
