using System.ComponentModel.DataAnnotations;
namespace RecipeForum.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }
        [Required]
        public User? User { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public double PrepTime { get; set; }

        [Required]
        public double CookingTime { get; set; }

        public string Description { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}