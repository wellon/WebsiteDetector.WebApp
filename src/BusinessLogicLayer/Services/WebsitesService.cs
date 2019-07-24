using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Infrastructure;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer.Services
{
    public class WebsitesService : IWebsitesService
    {
        private readonly IRepository<Website> repository;
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public WebsitesService(IRepository<Website> repository, IUnitOfWork uow, IMapper mapper)
        {
            this.repository = repository;
            this.uow = uow;
            this.mapper = mapper;
        }

        public IEnumerable<WebsiteDTO> GetWebsites()
        {
            var websites = repository.GetAll();
            return mapper.Map<List<WebsiteDTO>>(websites);
        }

        public void AddNewWebSite(CreateWebsiteDTO createWebsiteDTO)
        {
            if (IsWebsiteExist(createWebsiteDTO))
            {
                throw new AppException($"Сайт с url {createWebsiteDTO.Url} уже существует в базе");
            }

            var website = mapper.Map<Website>(createWebsiteDTO);

            //костыль из-за in-memory-db
            var idOfLastElement = repository.GetAll().Last().Id;
            website.Id = idOfLastElement + 1;

            repository.Add(website);
            uow.SaveChanges();
        }

        public bool IsWebsiteExist(CreateWebsiteDTO createWebsiteDTO)
        {
            return repository.Get(w => w.Url == createWebsiteDTO.Url).Any();
        }
    }
}
