using RecipeManagerWeb.Data;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public class GroceryCategoryRepository : GenericRepository<GroceryCategory>, IGroceryCategoryRepository
    {

        public GroceryCategoryRepository(DataContext context) : base(context)
        {

        }

    }
}
