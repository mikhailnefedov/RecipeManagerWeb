using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Dtos
{
    public class GetRecipeGroceryItemDto
    {
        public int GroceryItemId { get; set; }
        public string GroceryName { get; set; } = string.Empty;
        public double Amount { get; set; }
        public MeasurementUnit Measurementunit { get; set; }
    }
}