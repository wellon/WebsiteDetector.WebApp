using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.DTO;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUpdater
    {
        Task Update(List<WebsiteDTO> data);
    }
}