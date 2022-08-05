using System.ComponentModel.DataAnnotations;

namespace RecipeManagerWeb.Models
{
    public class GroceryCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<GroceryItem> GroceryItems { get; set; } = null!;
    }
}
