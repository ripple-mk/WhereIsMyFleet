using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhereIsMyFleet.Infrastructure;

namespace WhereIsMyFleet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                scope.ServiceProvider.GetService<SeedData>().Initialize();
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configBuilder = new ConfigurationBuilder()
               .SetBasePath(Environment.CurrentDirectory)

               .AddJsonFile("appsettings.json", false, true)
               .AddJsonFile($"appsettings.{environment}.json", true, true);
            return Host.CreateDefaultBuilder(args)
                .UseLamar()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .UseConfiguration(configBuilder.Build())
                    .UseStartup<Startup>();
                });
        }
    }
}
