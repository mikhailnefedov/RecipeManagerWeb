using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Dtos
{
    public class AddRecipeDto
    {
        public string Title { get; set; }
        public int RecipeCategoryId { get; set; }
        public double Amount { get; set; }
        public PortionUnit PortionUnit { get; set; }
        public int Time { get; set; }
        public Boolean Vegetarian { get; set; }
        public List<AddRecipeGroceryItemDto>? Ingredients { get; set; }
        public List<AddInstructionStepDto>? Instructions { get; set; }
        public string? Source { get; set; }
        public string? Comment { get; set; }
    }
}
