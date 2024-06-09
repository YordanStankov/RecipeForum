using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeForum.Models
{
    public class Upvote
    {
        public int Amount { get; set; }
        
        [ForeignKey(nameof(Recipe))]
        public int? RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
        
        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public User? User { get; set; }  
    }
}
