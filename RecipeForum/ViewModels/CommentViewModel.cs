using RecipeForum.Models;
using System.ComponentModel.DataAnnotations;

namespace RecipeForum.ViewModels
{
    public class CommentViewModel
    {
        public int? RecipeId { get; set; }
        public string? UserId { get; set; }
        public string? Description { get; set; }
    }
}
