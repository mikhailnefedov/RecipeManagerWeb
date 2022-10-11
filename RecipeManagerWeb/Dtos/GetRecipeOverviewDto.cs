using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Dtos
{
    public class GetSmallRecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public GetRecipeCategoryDto RecipeCategory { get; set; } = null!;
        public double? Amount { get; set; }
        public PortionUnit? PortionUnit { get; set; }
        public int? Time { get; set; }
        public bool? Vegetarian { get; set; }
    }
}
