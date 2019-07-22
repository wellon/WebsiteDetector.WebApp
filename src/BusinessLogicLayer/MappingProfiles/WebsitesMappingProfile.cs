using AutoMapper;
using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.MappingProfiles
{
    class WebsitesMappingProfile : Profile
    {
        public WebsitesMappingProfile()
        {
            CreateMap<Website, WebsiteDTO>()
                .ForMember(wd => wd.Id, opt => opt.MapFrom(w => w.Id))
                .ForMember(wd => wd.Name, opt => opt.MapFrom(w => w.Name));
            CreateMap<WebsiteDTO, Website>()
                .ForMember(w => w.Id, opt => opt.MapFrom(wd => wd.Id))
                .ForMember(w => w.Name, opt => opt.MapFrom(wd => wd.Name));

            CreateMap<CreateWebsiteDTO, Website>(MemberList.Source);
        }
    }
}
