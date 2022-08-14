namespace RecipeManagerWeb.Models
{
    public class ShoppingList
    {
        public Dictionary<GroceryItem, Dictionary<MeasurementUnit, double>> Groceries { get; }

        public ShoppingList()
        {
            Groceries = new Dictionary<GroceryItem, Dictionary<MeasurementUnit, double>>();
        }

        public void AddGroceryItems(List<RecipeGroceryItem> itemsToAdd)
        {
            itemsToAdd.ForEach(i => AddGroceryItem(i));
        }

        public void AddGroceryItem(RecipeGroceryItem itemToAdd)
        {
            if (isGroceryInList(itemToAdd.GroceryItem))
            {
                var amounts = Groceries[itemToAdd.GroceryItem];
                if (isMeasurementInDictionary(itemToAdd.Measurement, amounts))
                {
                    var amount = amounts[itemToAdd.Measurement] + itemToAdd.Amount;
                    amounts.Add(itemToAdd.Measurement, amount);
                }
                else
                {
                    amounts.Add(itemToAdd.Measurement, itemToAdd.Amount);
                }
            }
            else
            {
                var amounts = new Dictionary<MeasurementUnit, double>();
                amounts.Add(itemToAdd.Measurement, itemToAdd.Amount);
                Groceries.Add(itemToAdd.GroceryItem, amounts);
            }
        }

        private bool isGroceryInList(GroceryItem item) => Groceries.ContainsKey(item);
        private bool isMeasurementInDictionary(MeasurementUnit measurement, Dictionary<MeasurementUnit, double> amounts) =>
            amounts.ContainsKey(measurement);

    }
}
