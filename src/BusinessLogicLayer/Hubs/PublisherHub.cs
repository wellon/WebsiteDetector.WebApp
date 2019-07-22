using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Hubs
{
    public class PublisherHub : Hub
    {
        public async Task PublishUpdate()
        {
            await Clients.All.SendAsync("ReceiveMessage", "test");
        }
    }
}
