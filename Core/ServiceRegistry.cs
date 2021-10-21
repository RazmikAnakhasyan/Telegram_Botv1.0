using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ServiceRegistry
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICurrencyService, CurrrencyService>();
        }
    }
}
