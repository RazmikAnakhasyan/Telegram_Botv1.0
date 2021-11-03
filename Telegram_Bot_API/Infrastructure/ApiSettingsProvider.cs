using Microsoft.Extensions.Configuration;
using Shared.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infrastructure
{
    public class ApiSettingsProvider : ISettingsProvider
    {
        private readonly IConfiguration _configuration;

        public ApiSettingsProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string BaseCurrency => _configuration.GetSection("Configs")["BaseCurrency"];
    }
}
