using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Dtos
{
    public class AddRecipeDto
    {
        public string Name { get; set; } = string.Empty;
        public int RecipeCategoryId { get; set; }
        public double? Amount { get; set; }
        public PortionUnit? PortionUnit { get; set; }
        public int? Time { get; set; }
        public bool? Vegetarian { get; set; }
        public List<AddRecipeGroceryItemDto> Ingredients { get; set; } = new List<AddRecipeGroceryItemDto> { };
        public List<AddInstructionStepDto> Instructions { get; set; } = new List<AddInstructionStepDto> { };
        public string? Source { get; set; }
        public string? Comment { get; set; }
    }
}
