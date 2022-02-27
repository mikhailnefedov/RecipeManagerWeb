using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Dtos
{
    public class GetRecipeOverviewDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public RecipeCategory RecipeCategory { get; set; } = null!;
        public double? Amount { get; set; }
        public PortionUnit? PortionUnit { get; set; }
        public int? Time { get; set; }
        public bool? Vegetarian { get; set; }
    }
}
