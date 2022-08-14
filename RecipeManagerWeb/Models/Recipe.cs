using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeManagerWeb.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int RecipeCategoryId { get; set; }
        [ForeignKey("RecipeCategoryId")]
        public RecipeCategory RecipeCategory { get; set; } = null!;
        public double Amount { get; set; } = 1.0;
        public PortionUnit? PortionUnit { get; set; }
        public int? Time { get; set; }
        public bool? Vegetarian { get; set; }
        public List<RecipeGroceryItem> Ingredients { get; set; } = new List<RecipeGroceryItem>();
        public List<InstructionStep> Instructions { get; set; } = new List<InstructionStep>();
        public string? Source { get; set; }
        public string? Comment { get; set; }

        public List<RecipeGroceryItem> GetIngredientsForRequestedAmount(double requestedAmount)
        {
            Func<double, double, double> division = (x, y) => x / y;
            Func<double, double, double> multiply = (x, y) => x * y;
            var standardizingOperator = (Amount > 1.0) ? division : multiply;
            Ingredients.ForEach(i => i.Amount = standardizingOperator(i.Amount, Amount));

            Ingredients.ForEach(i => i.Amount = i.Amount * requestedAmount);
            return Ingredients;
        }
    }

}
