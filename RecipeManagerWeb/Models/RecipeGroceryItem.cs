using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeManagerWeb.Models
{
    public class RecipeGroceryItem
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;
        public int GroceryItemId { get; set; }
        public GroceryItem GroceryItem { get; set; } = null!;
        public double Amount { get; set; }
        public MeasurementUnit Measurementunit { get; set; }
    }

}
