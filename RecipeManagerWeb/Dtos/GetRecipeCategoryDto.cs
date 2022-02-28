namespace RecipeManagerWeb.Dtos
{
    public class GetRecipeCategoryDto
    {
        public int Id { get; set; }
        public string? Abbreviation { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}