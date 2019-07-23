using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.DTO;

namespace BusinessLogicLayer.Hubs
{
    public class PublisherHub : Hub<IUpdater>
    {
        public async Task BroadcastData(List<WebsiteDTO> data)
        {
            await Clients.All.Update(data);
        }
    }
}
