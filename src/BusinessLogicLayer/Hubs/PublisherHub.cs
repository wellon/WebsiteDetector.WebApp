using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Hubs
{
    public class PublisherHub : Hub<IUpdater>
    {
        public async Task BroadcastData(List<Website> data)
        {
            await Clients.All.Update(data);
        }
    }
}
