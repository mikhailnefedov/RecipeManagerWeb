using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeManagerWeb.Models
{
    public class GroceryItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int GroceryCategoryId { get; set; }
        [ForeignKey("GroceryCategoryId")]
        public GroceryCategory GroceryCategory { get; set; } = null!;
    }
}
