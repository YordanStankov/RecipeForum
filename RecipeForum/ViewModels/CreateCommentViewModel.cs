using RecipeForum.Models;
namespace RecipeForum.ViewModels
{
    public class CreateCommentViewModel
    {
        public int RecipeId { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
    }
}
