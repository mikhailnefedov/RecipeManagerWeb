namespace RecipeManagerWeb.Dtos
{
    public class UpdateGroceryItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int groceryCategoryId { get; set; }
    }
}
