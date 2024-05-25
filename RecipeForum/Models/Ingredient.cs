using System.ComponentModel.DataAnnotations;

namespace RecipeForum.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public double CaloriesPer100g { get; set; }

        [Required]
        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }


    }
}