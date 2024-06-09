using RecipeForum.Models;
namespace RecipeForum.ViewModels
{
    public class AccountScreenViewModel
    {
        //this is supposed to be the id of the user so it can be matched to recipes he has created
        public string UserId { get; set; }

        //for display at profile screen
       
        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

    }
}
