using Microsoft.AspNetCore.Mvc;
using sessionStateManagement.Models;
using System.Diagnostics;

namespace sessionStateManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string data = String.Empty;
            if(HttpContext.Session.Keys.Contains("first_request"))
            {
                string firstvisit = HttpContext.Session.GetString("first_request");
                data = "welcome back " + firstvisit;
            }
            else
            {
                data = "u visited first time";
                HttpContext.Session.SetString("first_request", System.DateTime.Now.ToString());
            }
            return View("index",data);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Remove()
        {
            HttpContext.Session.Remove("first_request");

            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}