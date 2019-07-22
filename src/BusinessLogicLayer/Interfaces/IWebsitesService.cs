using BusinessLogicLayer.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IWebsitesService
    {
        void AddNewWebSite(CreateWebsiteDTO createWebsiteDTO);
        IEnumerable<WebsiteDTO> GetWebsites();
        bool IsWebsiteExist(CreateWebsiteDTO createWebsiteDTO);
    }
}
