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
    public class DetailsModel : PageModel
    {
        private readonly RecipeManagerWeb.Data.DataContext _context;

        public DetailsModel(RecipeManagerWeb.Data.DataContext context)
        {
            _context = context;
        }

        public GroceryItem GroceryItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GroceryItem = await _context.GroceryItems.FirstOrDefaultAsync(m => m.Id == id);

            if (GroceryItem == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
