using RecipeManagerWeb.Models.Groceries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeManagerWeb.Models.Recipe
{
    public class RecipeGroceryItem
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int GroceryItemId { get; set; }
        public GroceryItem GroceryItem { get; set; }
        public double Amount { get; set; }
        public MeasurementUnit Measurementunit { get; set; }
    }

    public enum MeasurementUnit
    {
        Bund,
        Blatt,
        EL,
        Kg,
        Knolle,
        L,
        Pkg,
        St,
        TL,
        Würfel,
        Zehe
    }
}
