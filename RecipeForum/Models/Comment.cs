using System.ComponentModel.DataAnnotations;

namespace RecipeForum.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        
        public string? UserId { get; set; }
       
        public User? User { get; set; }

        [Required]
        public string? Description { get; set; }

        public int? RecipeId { get; set; }
        public Recipe? Recipe { get; set; }

    }
}