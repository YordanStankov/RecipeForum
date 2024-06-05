using RecipeForum.Models;
using System.ComponentModel.DataAnnotations;

namespace RecipeForum.ViewModels
{
    public class CreateRecipeViewModel
    {
        
        public Category Category { get; set; }

        [Required, StringLength(50, MinimumLength =5)]
        public string Name { get; set; }

        [Required]
        public double PrepTime { get; set; }

        [Required]
        public double CookingTime { get; set; }
        
        [Required, StringLength(500, MinimumLength =30)]
        public string Description { get; set; }

        [Required, StringLength(100, MinimumLength =8)]
        public string Ingredients { get; set; }
       
    }
}
