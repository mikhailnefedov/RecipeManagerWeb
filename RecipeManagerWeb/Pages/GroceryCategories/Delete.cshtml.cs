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
    public class DeleteModel : PageModel
    {
        private readonly RecipeManagerWeb.Data.DataContext _context;

        public DeleteModel(RecipeManagerWeb.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GroceryCategory = await _context.GroceryCategories.FindAsync(id);

            if (GroceryCategory != null)
            {
                _context.GroceryCategories.Remove(GroceryCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
