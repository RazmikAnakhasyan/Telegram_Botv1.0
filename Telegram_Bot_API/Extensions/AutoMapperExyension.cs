using API.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class AutoMapperExyension
    {
        public static void AddAutoMapperConfigurations(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(RatesProfile));

        }
    }
}
