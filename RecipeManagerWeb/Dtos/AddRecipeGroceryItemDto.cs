using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Dtos
{
    public class AddRecipeGroceryItemDto
    {
        public int RecipeId { get; set; }
        public int GroceryItemId { get; set; }
        public double Amount { get; set; }
        public MeasurementUnit Measurementunit { get; set; }
    }
}
