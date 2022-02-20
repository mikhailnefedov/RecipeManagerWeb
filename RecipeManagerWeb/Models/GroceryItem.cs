using System.ComponentModel.DataAnnotations;

namespace RecipeManagerWeb.Models
{
    public class GroceryItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public GroceryCategory Category { get; set; } = null!;
    }
}
