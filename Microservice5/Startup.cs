using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Consul;
using Microservice5.DataContext;
using Microservice5.Domain.Contracts;
using Microservice5.Domain.Repository;
using Microservice5.Domain.Service;
using Microservice5.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Microservice5
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
            services.AddHostedService<CompanyCatalogQueueReader>(serivces => new CompanyCatalogQueueReader(services.BuildServiceProvider().GetRequiredService<IStockExchangeService>()));
            var connection = Configuration.GetConnectionString("constr");
            services.AddDbContext<SeDBContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IStockExchangeRepository, StockExchangeRepository>();
            services.AddScoped<IStockExchangeService, StockExchangeService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "StockExchange Api",
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
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Stock Exchange Api"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var client = app.ApplicationServices.GetRequiredService<IConsulClient>();
            var registration = new AgentServiceRegistration()
            {
                Address = "localhost",
                Port = 54806,
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
