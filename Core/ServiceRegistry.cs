using Core.Services.Interfaces;
using Core.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public class ServiceRegistry
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICurrencies, Currencies>();
            services.AddScoped<IBestRates, BestRates>();
        }
    }
}
