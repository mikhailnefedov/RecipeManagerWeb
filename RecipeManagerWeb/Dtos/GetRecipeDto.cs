using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Dtos
{
    public class GetRecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public GetRecipeCategoryDto RecipeCategory { get; set; } = null!;
        public double? Amount { get; set; }
        public PortionUnit? PortionUnit { get; set; }
        public int? Time { get; set; }
        public bool? Vegetarian { get; set; }
        public List<GetRecipeGroceryItemDto> Ingredients { get; set; } = new List<GetRecipeGroceryItemDto>();
        public List<GetInstructionStepDto> Instructions { get; set; } = new List<GetInstructionStepDto>();
        public string? Source { get; set; }
        public string? Comment { get; set; }
    }
}
