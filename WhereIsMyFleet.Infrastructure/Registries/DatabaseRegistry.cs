using Lamar;
using Microsoft.Extensions.Configuration;
using WhereIsMyFleet.Core;

namespace WhereIsMyFleet.Infrastructure.Registries
{
    public class DatabaseRegistry : ServiceRegistry
    {
        public DatabaseRegistry()
        {
            For<WhereIsMyFleetDbContext>().Use(x =>
            {
                var c = x.GetInstance<IConfiguration>();
                return new WhereIsMyFleetDbContext(c.GetConnectionString("WhereIsMyFleet"));
            }).Scoped();
            
        }
    }
}
