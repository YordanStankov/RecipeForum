using RecipeForum.Models;
using RecipeForum.ViewModels;
using System.ComponentModel.DataAnnotations; 
namespace RecipeForum.ViewModels
{
    public class RecipeListViewModel
    {
        public int Id { get; set; } 
        public string? UserId {  get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double PrepTime { get; set; }
        [Required]
        public double CookingTime { get; set; }
        [Required]
        public Category Category { get; set; }
             
    }
}
