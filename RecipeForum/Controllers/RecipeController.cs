using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace RecipeForum.Controllers
{
    public class RecipeController : Controller
    {

        public IActionResult RecipeList()
        {
            //List<Recipe> list = getfromd;
            return View(IList);
        }
        public IActionResult RecipeCreation()
        {
            return View();
        }
    }
}
