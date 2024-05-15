namespace RecipeForum.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public double PrepTime { get; set; }
        public double CookingTime { get; set; }
        public List<string> Ingredients {  get; set; }
        public string Description { get; set; }

        
    }
}
