using System.ComponentModel.DataAnnotations;
namespace RecipeForum.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(80)]
        public string Name { get; set; }

        public string? UserId { get; set; }
        public User? User { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required, MaxLength(80)]
        public string Ingredients {  get; set; }
        [Required]
        public double PrepTime { get; set; }

        [Required]
        public double CookingTime { get; set; }
        [Required, MaxLength(500)]
        public string Description { get; set; }

        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Upvote>? Upvotes { get; set; }
    }
}