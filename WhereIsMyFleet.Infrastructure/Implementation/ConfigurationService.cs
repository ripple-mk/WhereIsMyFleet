using Microsoft.Extensions.Configuration;
using WhereIsMyFleet.Core.Abstractions;

namespace WhereIsMyFleet.Infrastructure.Implementation
{
    public class ConfigurationService : IConfigurationService
    {
        IConfiguration _configuration { get; set; }

        public ConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ConnectionString => _configuration.GetConnectionString("WhereIsMyFleet");
    }
}
