﻿using RecipeManagerWeb.Data;
using RecipeManagerWeb.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeManagerWeb.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly DataContext _context;

        public RecipeService(DataContext context)
        {
            _context = context;
        }

        public List<Recipe> GetRecipes()
        {
            List<Recipe> list = _context.Recipes.ToList();
            return list;
        }
    }
}
