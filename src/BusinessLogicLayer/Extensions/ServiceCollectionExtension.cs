using AutoMapper;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.MappingProfiles;
using BusinessLogicLayer.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            Mapper.Initialize(cfg => { cfg.AddProfiles(typeof(WebsitesMappingProfile).Assembly); });
            services.AddScoped<IMapper>(p => new Mapper(Mapper.Configuration));
        }

        public static void AddBLLServices(this IServiceCollection services)
        {
            services.AddTransient<IWebsitesService, WebsitesService>();
        }
    }
}
