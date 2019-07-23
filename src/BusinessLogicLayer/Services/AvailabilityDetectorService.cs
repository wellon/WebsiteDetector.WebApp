using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class AvailabilityDetectorService : IAvailabilityDetectorService
    {
        private readonly HttpClient client;
        private readonly IRepository<Website> repository;

        public AvailabilityDetectorService(HttpClient client, IRepository<Website> repository)
        {
            this.client = client;
            this.repository = repository;
        }

        public async Task<List<WebsiteDTO>> ProcessSiteCheck(CancellationToken token)
        {
            var websites = repository.GetAll().ToList();
            var tasksList = websites.Select(async obj => await CheckIsAvailable(obj, token)).ToList();
            var result = await Task.WhenAll(tasksList);
            return result.ToList();
        }

        private async Task<WebsiteDTO> CheckIsAvailable(Website website, CancellationToken token)
        {
            try
            {
                using (var response = await client.GetAsync(website.Url, HttpCompletionOption.ResponseHeadersRead, token))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return new WebsiteDTO { Id = website.Id, Name = website.Name, Status = true};
                    }
                    else
                    {
                        return new WebsiteDTO { Id = website.Id, Name = website.Name, Status = false };
                    }
                }
            }
            catch
            {
                return new WebsiteDTO { Id = website.Id, Name = website.Name, Status = false };
            }
        }
    }
}
