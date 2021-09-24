using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeManagerWeb.Data;
using RecipeManagerWeb.Models.Recipe;

namespace RecipeManagerWeb.Pages
{
    public class AddRecipeModel : PageModel
    {
        private readonly DataContext Context;
        public SelectList PortionUnits;

        public AddRecipeModel(DataContext context)
        {
            Context = context;
        }

        public IActionResult OnGet()
        {
            PopulatePortionUnits();
            return Page();
        }

        [BindProperty]
        public Recipe Recipe { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Context.Recipes.Add(Recipe);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public void PopulatePortionUnits()
        {
            List<string> list = Enum.GetValues(typeof(PortionUnit))
                .Cast<PortionUnit>()
                .Select(p => p.ToString())
                .ToList();

            PortionUnits = new SelectList(list);
        }
    }
}
