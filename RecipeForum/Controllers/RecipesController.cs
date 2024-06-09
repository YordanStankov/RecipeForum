using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using RecipeForum.Models;
using RecipeForum.ViewModels;
using RecipeForum.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Identity;

namespace RecipeForum.Controllers
{
    public class RecipesController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<User> _userManager;

        public RecipesController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
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
                Comments = curRecipe.Comments.Select(c => new CommentViewModel()
                {
                    UserId = c.UserId,
                    RecipeId = c.RecipeId,
                    Description = c.Description
                }).ToList()
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
       public IActionResult CreateComment(CreateCommentViewModel Comment)
        {
            Comment commentFloat = new Comment()
            {
                UserId = _userManager.GetUserId(User),
                RecipeId = Comment.RecipeId,
                Description = Comment.Description,
            };
            _context.Add(commentFloat);
            _context.SaveChanges();
            return RedirectToAction("FocusRecipe", "Recipes", new {Id = commentFloat.RecipeId});
        }
       public IActionResult DeleteRecipe(int DeleteId)
        {
            var Recipe = _context.Recipes.FirstOrDefault(r => r.Id == DeleteId);
            if(Recipe is not null)
            {
                _context.Recipes.Remove(Recipe);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
