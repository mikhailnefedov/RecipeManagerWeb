using RecipeManagerWeb.Data;
using RecipeManagerWeb.Models.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeManagerWeb.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly DataContext Context;

        public RecipeService(DataContext context)
        {
            Context = context;
        }

        public List<Recipe> GetRecipes()
        {
            List<Recipe> list = Context.Recipes.ToList();
            return list;
        }
    }
}
