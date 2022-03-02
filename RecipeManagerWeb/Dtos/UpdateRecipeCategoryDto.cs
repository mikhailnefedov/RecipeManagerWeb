namespace RecipeManagerWeb.Dtos
{
    public class UpdateRecipeCategoryDto
    {
        public int Id { get; set; }
        public string? Abbreviation { get; set; }
        public string Name { get; set; } = String.Empty;
    }
}
