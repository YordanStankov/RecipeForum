using Microsoft.AspNetCore.Mvc;
using RecipeForum.Models;
using System.Diagnostics;
using RecipeForum.ViewModels;
using RecipeForum.Data;

namespace RecipeForum.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(CommentViewModel commentView)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult RecipeCreation()
        {
            return View();
        }

        public IActionResult NoBueno()
        {
            return View();
        }

        public IActionResult MakeAnAccount()
        {
            return View();
        }
       
        public IActionResult GreatSucces()
        {
            return View();
        }
        public IActionResult Destroyed() 
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
