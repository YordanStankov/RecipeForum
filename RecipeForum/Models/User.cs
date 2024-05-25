using System.ComponentModel.DataAnnotations;

namespace RecipeForum.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(25)]
        public string Username { get; set; }

        public int CommentId { get; set; }
        public ICollection<Recipe> Recipes => new List<Recipe>();

    }
}