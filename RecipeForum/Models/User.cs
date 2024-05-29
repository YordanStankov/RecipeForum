using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RecipeForum.Models
{
    public class User : IdentityUser
    {
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Recipe> Recipes => new List<Recipe>();

    }
}