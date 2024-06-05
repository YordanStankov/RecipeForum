using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using RecipeForum.Models;
using RecipeForum.ViewModels;
using RecipeForum.Data;

namespace RecipeForum.Controllers
{
    public class RecipesController : Controller
    {

        public IActionResult RecipeList()
        {
            return View();
        }
        public IActionResult RecipeCreation()
        {
            return View();
        }
        public IActionResult AddIngredient()
        {
            return View(); 
        }

        private ApplicationDbContext _context;
        public RecipesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateRecipe(CreateRecipeViewModel Recipe)
        {
            Recipe RecipeFloat = new Recipe() { 
                Name= Recipe.Name, 
                Category = Recipe.Category, 
                Description = Recipe.Description, 
                CookingTime = Recipe.CookingTime,
                PrepTime = Recipe.PrepTime,
                Ingredients = Recipe.Ingredients
            };
            _context.Add(RecipeFloat);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home"); 
        }

    }
}
