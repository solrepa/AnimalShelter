using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalShelter.Api.HealthChecks;
using AnimalShelter.Data.Sql;
using AnimalShelter.Data.Sql.Migrations;
using AnimalShelter.API.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace AnimalShelter.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private const string MySqlHealthCheckName = "mysql";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AnimalShelterDbContext>(options => options
                .UseMySQL(Configuration.GetConnectionString("AnimalShelterDbContext")));
            services.AddTransient<DatabaseSeed>();
            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            //dodanie health checku i konfiguracja health checku dla MySqla
            services.AddHealthChecks()
                .AddMySql(
                    Configuration.GetConnectionString("AnimalShelterDbServer"),
                    5,
                    10,
                    MySqlHealthCheckName);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //wystawienie pod adresem /healthy stanu healthchecków
            app.UseHealthChecks("/healthy");

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AnimalShelterDbContext>();
                var databaseSeed = serviceScope.ServiceProvider.GetRequiredService<DatabaseSeed>();

                var healthCheck = serviceScope.ServiceProvider.GetRequiredService<HealthCheckService>();
                if (healthCheck.CheckHealthAsync().Result?.Entries[MySqlHealthCheckName].Status == HealthCheckResult.Healthy().Status)
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    databaseSeed.Seed();
                }
            }

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseRouting();

            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
            });
           

        }
    }
}
