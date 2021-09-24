using RecipeManagerWeb.Models.Groceries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeManagerWeb.Models.Recipes
{
    public class RecipeGroceryItem
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int GroceryItemId { get; set; }
        public GroceryItem GroceryItem { get; set; }
        public double Amount { get; set; }
        public MeasurementUnit AmountUnit { get; set; }
    }

    public enum MeasurementUnit
    {
        Bund,
        Blatt,
        EL,
        Kg,
        Knolle,
        L,
        Packung,
        Stück,
        TL,
        Würfel,
        Zehe
    }
}
