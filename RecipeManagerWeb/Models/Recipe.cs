using System.ComponentModel.DataAnnotations;

namespace RecipeManagerWeb.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public RecipeCategory RecipeCategory { get; set; } = null!;
        public double? Amount { get; set; }
        public PortionUnit? PortionUnit { get; set; }
        public int? Time { get; set; }
        public bool? Vegetarian { get; set; }
        public List<RecipeGroceryItem> Ingredients { get; set; } = new List<RecipeGroceryItem>();
        public List<InstructionStep> Instructions { get; set; } = new List<InstructionStep>();
        public string? Source { get; set; }
        public string? Comment { get; set; }
    }

}
