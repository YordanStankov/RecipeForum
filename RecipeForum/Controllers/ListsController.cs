using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using RecipeForum.Models;
using RecipeForum.ViewModels;
using RecipeForum.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace RecipeForum.Controllers
{
    public class ListsController : Controller
    {
        private ApplicationDbContext _context;
        public ListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult BreakfastRecipeList()
        {
            var recipes = _context.Recipes.Where(n => n.Category == 0).Select(n => new RecipeListViewModel()
            {
                Id = n.Id,
                Name = n.Name,
                CookingTime = n.CookingTime,
                PrepTime = n.PrepTime,
                Category = n.Category,
            }).ToList();

            return View(recipes);
        }
        public IActionResult LunchRecipeList()
        {
            var recipes = _context.Recipes.Where(n => n.Category == Category.Lunch).Select(n => new RecipeListViewModel()
            {
                Id = n.Id,
                Name = n.Name,
                CookingTime = n.CookingTime,
                PrepTime = n.PrepTime,
                Category = n.Category,
            }).ToList();

            return View(recipes);
        }
        public IActionResult DinnerRecipeList()
        {
            var recipes = _context.Recipes.Where(n => n.Category == Category.Dinner).Select(n => new RecipeListViewModel()
            {
                Id = n.Id,
                Name = n.Name,
                CookingTime = n.CookingTime,
                PrepTime = n.PrepTime,
                Category = n.Category,
            }).ToList();

            return View(recipes);
        }
    }
}
