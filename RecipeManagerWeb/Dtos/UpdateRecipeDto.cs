using RecipeManagerWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace RecipeManagerWeb.Dtos
{
    public class UpdateRecipeDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int recipeCategoryId { get; set; }
        public double? Amount { get; set; }
        public PortionUnit? PortionUnit { get; set; }
        public int? Time { get; set; }
        public bool? Vegetarian { get; set; }
        public List<UpdateRecipeGroceryItemDto> Ingredients { get; set; } = new List<UpdateRecipeGroceryItemDto>();
        public List<UpdateInstructionStepDto> Instructions { get; set; } = new List<UpdateInstructionStepDto>();
        public string? Source { get; set; }
        public string? Comment { get; set; }
    }

    public class UpdateRecipeGroceryItemDto
    {
        public int GroceryItemId { get; set; }
        public double Amount { get; set; }
        public MeasurementUnit Measurementunit { get; set; }
    }

    public class UpdateInstructionStepDto
    {
        public string Text { get; set; } = string.Empty;
    }

}
