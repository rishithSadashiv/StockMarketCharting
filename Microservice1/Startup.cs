using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice3.DataContext;
using Microservice3.Domain.Contracts;
using Microservice3.Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.OpenApi.Models;
using Microservice3.Domain.Services;
using Consul;

namespace Microservice1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHostedService<CompanyCatalogQueueReader>(serivces => new CompanyCatalogQueueReader(services.BuildServiceProvider().GetRequiredService<ICompanyService>()));
            var connection = Configuration.GetConnectionString("constr");
            services.AddDbContext<SectorDBContext>(options => options.UseSqlServer(connection));
            services.AddScoped<ISectorRepository, SectorRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ISectorService, SectorService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "Sector Api",
                Version = "v1"
            }));
            services.AddCors();
            services.AddSingleton<IConsulClient, ConsulClient>(options => new ConsulClient(config => {
                config.Address = new Uri(Configuration["ConsulConfig:Host"]);
            }));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Sector Api"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var client = app.ApplicationServices.GetRequiredService<IConsulClient>();
            var registration = new AgentServiceRegistration()
            {
                Address = "localhost",
                Port = 57532,
                Name = Configuration["ConsulConfig:ServiceName"],
                ID = Configuration["ConsulConfig:ServiceId"]
            };

            var applifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();
            applifetime.ApplicationStarted.Register(() => client.Agent.ServiceRegister(registration).ConfigureAwait(true));

            applifetime.ApplicationStopped.Register(() => client.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true));

            app.UseCors(settings => settings.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
