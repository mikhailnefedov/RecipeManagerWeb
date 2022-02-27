using AutoMapper;
using RecipeManagerWeb.Data;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public class RecipeCategoryRepository : IRecipeCategoryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public RecipeCategoryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RecipeCategory> AddRecipeCategory(AddRecipeCategoryDto newRecipeCategory)
        {
            RecipeCategory category = _mapper.Map<RecipeCategory>(newRecipeCategory);

            await _context.RecipeCategories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }
    }
}
