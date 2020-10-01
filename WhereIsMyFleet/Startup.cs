using Lamar;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using WhereIsMyFleet.Core;
using WhereIsMyFleet.Infrastructure.Extensions;
using WhereIsMyFleet.Infrastructure.HttpMiddleware;

namespace WhereIsMyFleet
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureContainer(ServiceRegistry services)
        {
            services.AddControllersWithViews().AddControllersAsServices().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                x.JsonSerializerOptions.MaxDepth = 255;
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            services.AddEntityFrameworkSqlServer();

            services.AddSwaggerGen(c =>
            {
                c.AddServer(new OpenApiServer
                {
                    Url = "http://localhost:5000",
                    Description = "HTTP endpoint"
                });
                c.AddServer(new OpenApiServer
                {
                    Url = "https://localhost:5001",
                    Description = "HTTP endpoint with SSL"
                });
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Where Is My Fleet API", Version = "v1" });
                c.CustomSchemaIds((t) =>
                {
                    return t.FullName.Replace("+", "");
                });
            });

            //var applicationServicesAssembly = Assembly.Load();
            services.AddMediatR(typeof(WhereIsMyFleet.Services.CurrentUserModel).Assembly);
            services.For<IConfiguration>().Use(Configuration);
            services.AddDbContext<WhereIsMyFleetDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("WhereIsMyFleet")));
            services.SetupRegistries();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();


            app.UseMiddleware<ExceptionHandlingFilter>();

            app.UseSwagger();
            app.UseSwaggerUI(setup =>
            {
                setup.EnableValidator();
                setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Hiketivity API");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
