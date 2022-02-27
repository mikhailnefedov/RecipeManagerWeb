namespace RecipeManagerWeb.Dtos
{
    public class GetGroceryItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int groceryCategoryId { get; set; }
        public string groceryCategoryName { get; set; } = string.Empty;
    }
}
