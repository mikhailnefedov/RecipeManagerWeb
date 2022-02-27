namespace RecipeManagerWeb.Dtos
{
    public class GetGroceryItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int groceryCategoryId;
        public string groceryCategoryName = string.Empty;
    }
}
