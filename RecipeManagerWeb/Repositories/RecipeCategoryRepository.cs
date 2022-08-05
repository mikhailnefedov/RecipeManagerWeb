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

        public async Task<GetRecipeCategoryDto> AddRecipeCategory(AddRecipeCategoryDto newRecipeCategory)
        {
            RecipeCategory recipeCategory = _mapper.Map<RecipeCategory>(newRecipeCategory);
            await _context.RecipeCategories.AddAsync(recipeCategory);
            return _mapper.Map<GetRecipeCategoryDto>(recipeCategory);
        }

        public async Task<GetRecipeCategoryDto?> GetRecipeCategory(int categoryId)
        {
            var recipeCategory = await _context.RecipeCategories.FindAsync(categoryId);
            return recipeCategory != null ? _mapper.Map<GetRecipeCategoryDto>(recipeCategory) : null;
        }

        public async Task<List<GetRecipeCategoryDto>> GetRecipeCategories()
        {
            var recipeCategories = await _context.RecipeCategories.ToListAsync();
            return recipeCategories.Select(c => _mapper.Map<GetRecipeCategoryDto>(c)).ToList();
        }

        public async Task<bool> DeleteRecipeCategory(int recipeCategoryId)
        {
            var recipeCategory = await _context.RecipeCategories.FindAsync(recipeCategoryId);
            if (recipeCategory is null) return false;

            bool usedInRecipes = await _context.Recipes.AnyAsync(recipe => recipe.RecipeCategory == recipeCategory);

            if (usedInRecipes)
            {
                return false;
            }
            else
            {
                _context.RecipeCategories.Remove(recipeCategory);
                return true;
            }
        }

        public async Task<GetRecipeCategoryDto?> UpdateRecipeCategory(UpdateRecipeCategoryDto updatedRecipeCategory)
        {

            RecipeCategory? recipeCategory = await _context.RecipeCategories.FindAsync(updatedRecipeCategory.Id);
            if (recipeCategory is null) return null;
            _mapper.Map(updatedRecipeCategory, recipeCategory);
            return _mapper.Map<GetRecipeCategoryDto>(recipeCategory);
        }

    }
}
