using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeManagerWeb.Data;
using RecipeManagerWeb.Models.RecipeCategories;

namespace RecipeManagerWeb.Pages.RecipeCategories
{
    public class CreateModel : PageModel
    {
        private readonly RecipeManagerWeb.Data.DataContext _context;

        public CreateModel(RecipeManagerWeb.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RecipeCategory RecipeCategory { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RecipeCategories.Add(RecipeCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
