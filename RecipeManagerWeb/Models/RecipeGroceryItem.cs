namespace RecipeManagerWeb.Models
{
    public class RecipeGroceryItem
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int GroceryItemId { get; set; }
        public GroceryItem GroceryItem { get; set; }
        public double Amount { get; set; }
        public MeasurementUnit Measurementunit { get; set; }
    }

    public enum MeasurementUnit
    {
        Kg,
        L
    }
}
