using Microsoft.Extensions.DependencyInjection;
using Core.Services;
 

namespace Core
{
   public class ServiceRegistry
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IBestAvailableRateService, BestAvailableRateService>();
 
        }
  
    }
}
