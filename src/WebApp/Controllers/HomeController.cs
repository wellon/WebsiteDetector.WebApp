using System.Diagnostics;
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
            var data = websitesService.GetWebsites();
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
