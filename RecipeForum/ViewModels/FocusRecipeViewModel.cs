using RecipeForum.Models;
using System.ComponentModel.DataAnnotations;

namespace RecipeForum.ViewModels
{
    public class FocusRecipeViewModel
    {
        public int Id { get; set; } 
        [Required]
        public string UserId { get; set; }
        public string? Name { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public string Ingredients { get; set; }
        [Required]
        public double PrepTime { get; set; }
        [Required]
        public double CookingTime { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<CommentViewModel>? Comments { get; set; }
        public ICollection<Upvote>? Upvotes { get; set; }
    }
}
