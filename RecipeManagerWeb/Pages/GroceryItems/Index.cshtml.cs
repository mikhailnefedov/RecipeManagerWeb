using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeManagerWeb.Data;
using RecipeManagerWeb.Models.Groceries;

namespace RecipeManagerWeb.Pages.GroceryItems
{
    public class IndexModel : PageModel
    {
        private readonly RecipeManagerWeb.Data.DataContext _context;

        public IndexModel(RecipeManagerWeb.Data.DataContext context)
        {
            _context = context;
        }

        public IList<GroceryItem> GroceryItem { get;set; }

        public async Task OnGetAsync()
        {
            GroceryItem = await _context.GroceryItems.ToListAsync();
        }
    }
}
