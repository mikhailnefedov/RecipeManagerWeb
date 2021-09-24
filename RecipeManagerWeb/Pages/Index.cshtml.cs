﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RecipeManagerWeb.Models.Recipe;
using RecipeManagerWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeManagerWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IRecipeService recipeService)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
