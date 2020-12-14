using Microservice3.Domain.Contracts;
using Microservice3.Dtos;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Microservice3.Domain.Services
{
    public class CompanyCatalogQueueReader : BackgroundService
    {
        ICompanyService service;
        public CompanyCatalogQueueReader(ICompanyService service)
        {
            this.service = service;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("CompanyCatalogMessages", true, false, false, null);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += UpdateCompanyDetails;
            channel.BasicConsume("CompanyCatalogMessages",false,consumer);
            return Task.CompletedTask;

        }

        private void UpdateCompanyDetails(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var json = Encoding.UTF8.GetString(body);
            Company2Dto Dto = JsonConvert.DeserializeObject<Company2Dto>(json);
            service.UpdateCompanyDetailsFromMS2(Dto);
        }
    }
}
