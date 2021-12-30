namespace RecipeManagerWeb.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public RecipeCategory RecipeCategory { get; set; }
        public double Amount { get; set; }
        public PortionUnit PortionUnit { get; set; }
        public int Time { get; set; }
        public Boolean Vegetarian { get; set; }
        public List<RecipeGroceryItem> Ingredients { get; set; }
        public List<InstructionStep> Instructions { get; set; }
        public string Source { get; set; }
        public string Comment { get; set; }
    }

    public enum PortionUnit
    {
        Bun,
        Bread,
        Cake,
        Portion,
    }
}
