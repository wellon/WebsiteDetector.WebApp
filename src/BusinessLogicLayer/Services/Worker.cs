using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using BusinessLogicLayer.Hubs;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;

namespace BusinessLogicLayer.Services
{
    public class Worker : BackgroundService
    {
        private readonly IHubContext<PublisherHub, IUpdater> publisherHub;
        private readonly WebsitesService websitesService;

        public Worker(IHubContext<PublisherHub, IUpdater> publisherHub, WebsitesService websitesService)
        {
            this.publisherHub = publisherHub;
            this.websitesService = websitesService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                var data = new List<Website>
                {
                    new Website{ Id = 1, Name = "Google", Url = "Google.com" },
                    new Website{ Id = 2, Name = "Yandex", Url = "Yandex.ru" },
                    new Website{ Id = 3, Name = "Amazon", Url = "Amazon.com" }
                };
                await publisherHub.Clients.All.Update(data);
                await Task.Delay(1000);
            }
        }
    }
}