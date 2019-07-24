using System;
using System.Diagnostics;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Infrastructure;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebsitesService websitesService;

        public HomeController(IWebsitesService websitesService)
        {
            this.websitesService = websitesService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddWebsite()
        {
            var websiteViewModel = new WebsiteViewModel();
            return View(websiteViewModel);
        }

        [HttpPost]
        public IActionResult AddWebsite(WebsiteViewModel website)
        {
            try
            {
                var createWebsiteDTO = new CreateWebsiteDTO
                    {Id = website.WebsiteId, Name = website.Name, Url = website.Url};
                websitesService.AddNewWebSite(createWebsiteDTO);
            }
            catch (AppException e)
            {
                return Content(e.Message);
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
