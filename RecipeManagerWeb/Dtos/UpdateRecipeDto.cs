using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Dtos
{
    public class UpdateRecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public UpdateRecipeRecipeCategoryDto RecipeCategory { get; set; }
        public double? Amount { get; set; }
        public PortionUnit? PortionUnit { get; set; }
        public int? Time { get; set; }
        public bool? Vegetarian { get; set; }
        public List<UpdateRecipeGroceryItemDto> Ingredients { get; set; } = new List<UpdateRecipeGroceryItemDto>();
        public List<UpdateInstructionStepDto> Instructions { get; set; } = new List<UpdateInstructionStepDto>();
        public string? Source { get; set; }
        public string? Comment { get; set; }
    }

    public class UpdateRecipeRecipeCategoryDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public string Abbreviation { get; set; }
    }

    public class UpdateRecipeGroceryItemDto
    {
        public int GroceryItemId { get; set; }
        public double Amount { get; set; }
        public MeasurementUnit Measurement { get; set; }
    }

    public class UpdateInstructionStepDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
    }

}
