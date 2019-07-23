using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IAvailabilityDetectorService
    {
        Task<List<WebsiteDTO>> ProcessSiteCheck(CancellationToken token);
    }
}