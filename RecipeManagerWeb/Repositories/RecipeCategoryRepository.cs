using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<GetRecipeCategoryDto?> GetRecipeCategory(int categoryId)
        {
            var recipeCategory = await _context.RecipeCategories.FindAsync(categoryId);

            if (recipeCategory is not null)
            {
                GetRecipeCategoryDto dto = _mapper.Map<GetRecipeCategoryDto>(recipeCategory);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<GetRecipeCategoryDto>> GetRecipeCategories()
        {
            var recipeCategories = await _context.RecipeCategories.ToListAsync();

            return recipeCategories.Select(c => _mapper.Map<GetRecipeCategoryDto>(c)).ToList();
        }

        public async Task<bool> DeleteRecipeCategory(int recipeCategoryId)
        {
            try
            {
                var recipeCategory = await _context.RecipeCategories.FindAsync(recipeCategoryId);
                if (recipeCategory is null) return false;

                int relatedRecipesCount = await _context.Recipes.Where(recipe => recipe.RecipeCategory == recipeCategory).CountAsync();

                if (relatedRecipesCount == 0)
                {

                    _context.RecipeCategories.Remove(recipeCategory);
                    await _context.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
