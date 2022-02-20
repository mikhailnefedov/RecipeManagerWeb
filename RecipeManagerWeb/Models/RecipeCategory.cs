using System.ComponentModel.DataAnnotations;

namespace RecipeManagerWeb.Models
{
    public class RecipeCategory
    {
        [Key]
        public int Id { get; set; }
        public string? Abbreviation { get; set; }    
        public string Name { get; set; } = String.Empty;
    }
}
