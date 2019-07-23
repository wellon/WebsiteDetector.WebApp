using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Hubs;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BusinessLogicLayer.Services
{
    public class Worker : BackgroundService
    {
        private readonly IHubContext<PublisherHub, IUpdater> publisherHub;
        private readonly IServiceProvider provider;

        public Worker(IHubContext<PublisherHub, IUpdater> publisherHub, IServiceProvider serviceProvider)
        {
            this.publisherHub = publisherHub;
            this.provider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var data = new List<WebsiteDTO>();

                using (IServiceScope scope = provider.CreateScope())
                {
                    var availabilityDetector = scope.ServiceProvider.GetRequiredService<IAvailabilityDetectorService>();
                    data = await availabilityDetector.ProcessSiteCheck(stoppingToken);
                }

                await publisherHub.Clients.All.Update(data);
                await Task.Delay(1000);
            }
        }
    }
}