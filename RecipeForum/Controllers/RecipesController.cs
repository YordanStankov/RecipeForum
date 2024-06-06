﻿using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using RecipeForum.Models;
using RecipeForum.ViewModels;
using RecipeForum.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace RecipeForum.Controllers
{
    public class RecipesController : Controller
    {
        private ApplicationDbContext _context;
        public RecipesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult RecipeList()
        {
            var recipes = _context.Recipes.Select(n => new RecipeListViewModel()
            {
                Id = n.Id,
                Name = n.Name,
                CookingTime = n.CookingTime,
                PrepTime = n.PrepTime,
            }).ToList();

            return View(recipes);
        }
        public async Task<IActionResult> FocusRecipe(int id)
        {
            var curRecipe = await _context.Recipes.
                Include(n => n.Comments).
                Include(n => n.Upvotes).
                FirstOrDefaultAsync(p => p.Id == id);
            if(curRecipe == null)
            {
                return NotFound();
            }
            var focusRecipe = new FocusRecipeViewModel
            {
                Id = curRecipe.Id,  
                Name = curRecipe.Name,
                CookingTime = curRecipe.CookingTime,
                PrepTime = curRecipe.PrepTime,
                Ingredients = curRecipe.Ingredients,
                Description = curRecipe.Description,
                Category = curRecipe.Category,
            };
            return View(focusRecipe);
        }
        public IActionResult RecipeCreation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateRecipe(CreateRecipeViewModel Recipe)
        {
            Recipe RecipeFloat = new Recipe() {
                Name = Recipe.Name,
                UserId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
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
