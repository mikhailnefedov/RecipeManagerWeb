using RecipeManagerWeb.Models.Groceries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeManagerWeb.Services
{
    public interface IGroceryCategoryService
    {
        List<GroceryCategory> GetAllGroceryCategories();
    }
}
