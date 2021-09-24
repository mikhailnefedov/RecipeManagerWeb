using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeManagerWeb.Data;
using RecipeManagerWeb.Models.RecipeCategories;

namespace RecipeManagerWeb.Pages.RecipeCategories
{
    public class DeleteModel : PageModel
    {
        private readonly RecipeManagerWeb.Data.DataContext _context;

        public DeleteModel(RecipeManagerWeb.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RecipeCategory RecipeCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RecipeCategory = await _context.RecipeCategories.FirstOrDefaultAsync(m => m.Id == id);

            if (RecipeCategory == null)
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

            RecipeCategory = await _context.RecipeCategories.FindAsync(id);

            if (RecipeCategory != null)
            {
                _context.RecipeCategories.Remove(RecipeCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
