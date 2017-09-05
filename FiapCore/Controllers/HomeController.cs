using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FiapCore.Services;
using Microsoft.Extensions.Configuration;

namespace FiapCore.Controllers
{
    public class HomeController : Controller
    {
        private ISerieService _serieService;
        private IConfigurationRoot _configuration;

        public HomeController(ISerieService serieService, IConfigurationRoot configuration)
        {
            _serieService = serieService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var connection = _configuration.GetConnectionString("ConnectionStrings");
            var urlPrincipal = _configuration.GetSection("AppSettings").GetValue<string>("UrlPrincipal");
            return View(_serieService.GetAll());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
