using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Dtos
{
    public class ShoppingListDto
    {
        public List<ShoppingListItem> Items { get; set; }

        public static ShoppingListDto ConvertFromShoppingList(ShoppingList list)
        {
            var items = list.Groceries.Keys.ToList()
                .Select(item => new ShoppingListItem()
                {
                    GroceryItem = item.Name,
                    GroceryCategory = item.GroceryCategory.Name,
                    Amounts = list.Groceries[item]
                }).ToList();

            return new ShoppingListDto { Items = items };
        }
    }

    public class ShoppingListItem
    {
        public string GroceryItem { get; set; }
        public string GroceryCategory { get; set; }
        public Dictionary<MeasurementUnit, double> Amounts { get; set; } = new Dictionary<MeasurementUnit, double>();
    }

}
