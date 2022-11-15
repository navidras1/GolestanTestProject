using GolestanTestProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DataAccess.Models;
using DataAccess.Repository;
namespace GolestanTestProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGolestanTestRepos<RetailStore> _retailStore;

        public HomeController(ILogger<HomeController> logger, IGolestanTestRepos<RetailStore> retailStore)
        {
            _logger = logger;
            _retailStore = retailStore;
        }

        public IActionResult Index()
        {

            var res= _retailStore.GetAll().ToList();
            return View();
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