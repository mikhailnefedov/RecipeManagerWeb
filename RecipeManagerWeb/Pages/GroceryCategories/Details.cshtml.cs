using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeManagerWeb.Data;
using RecipeManagerWeb.Models.Groceries;

namespace RecipeManagerWeb.Pages.GroceryCategories
{
    public class DetailsModel : PageModel
    {
        private readonly RecipeManagerWeb.Data.DataContext _context;

        public DetailsModel(RecipeManagerWeb.Data.DataContext context)
        {
            _context = context;
        }

        public GroceryCategory GroceryCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GroceryCategory = await _context.GroceryCategories.FirstOrDefaultAsync(m => m.Id == id);

            if (GroceryCategory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
