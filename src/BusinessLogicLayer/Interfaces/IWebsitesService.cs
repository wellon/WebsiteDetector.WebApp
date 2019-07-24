using BusinessLogicLayer.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IWebsitesService
    {
        IEnumerable<WebsiteDTO> GetWebsites();
        void AddNewWebSite(CreateWebsiteDTO createWebsiteDTO);
    }
}
