using RecipeManagerWeb.Models.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeManagerWeb.Services
{
    public interface IRecipeService
    {
        public List<Recipe> GetRecipes();
    }
}
