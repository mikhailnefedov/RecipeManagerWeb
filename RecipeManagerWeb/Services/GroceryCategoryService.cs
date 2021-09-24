using RecipeManagerWeb.Data;
using RecipeManagerWeb.Models.Groceries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeManagerWeb.Services
{
    public class GroceryCategoryService : IGroceryCategoryService
    {
        private readonly DataContext _context;

        public GroceryCategoryService(DataContext context)
        {
            _context = context;
        }

        public List<GroceryCategory> GetAllGroceryCategories()
        {
            return _context.GroceryCategories.ToList();
        }
    }
}
