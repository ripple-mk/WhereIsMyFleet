using Lamar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WhereIsMyFleet.Infrastructure.Registries;
using WhereIsMyFleet.Services;

namespace WhereIsMyFleet.Infrastructure.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static ServiceRegistry SetupRegistries(this ServiceRegistry services)
        {
            services.IncludeRegistry<AbstractionsRegistry>();
            services.IncludeRegistry<DatabaseRegistry>();
            services.IncludeRegistry<MediatrRegistry>();
            return services;
        }
    }
}
