using Lamar;
using WhereIsMyFleet.Core.Abstractions;
using WhereIsMyFleet.Infrastructure.Implementation;

namespace WhereIsMyFleet.Infrastructure.Registries
{
    public class AbstractionsRegistry : ServiceRegistry
    {
        public AbstractionsRegistry()
        {
            For<IConfigurationService>().Use<ConfigurationService>().Singleton();
        }
    }
}
