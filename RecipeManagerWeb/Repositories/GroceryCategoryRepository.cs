using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecipeManagerWeb.Data;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public class GroceryCategoryRepository : IGroceryCategoryRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GroceryCategoryRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<GetGroceryCategoryDto> AddGroceryCategory(string categoryName)
        {
            GroceryCategory groceryCategory = new GroceryCategory { Name = categoryName };
            await _context.GroceryCategories.AddAsync(groceryCategory);
            return _mapper.Map<GetGroceryCategoryDto>(groceryCategory);
        }

        public async Task<GetGroceryCategoryDto?> GetGroceryCategory(int groceryCategoryId)
        {
            var groceryCategory = await _context.GroceryCategories.FindAsync(groceryCategoryId);
            return groceryCategory != null ? _mapper.Map<GetGroceryCategoryDto>(groceryCategory) : null;
        }

        public async Task<List<GetGroceryCategoryDto>> GetGroceryCategories()
        {
            var groceryCategories = await _context.GroceryCategories.ToListAsync();
            return groceryCategories.Select(c => _mapper.Map<GetGroceryCategoryDto>(c)).ToList();
        }

        public async Task<bool> DeleteGroceryCategory(int groceryCategoryId)
        {
            var groceryCategory = await _context.GroceryCategories.FindAsync(groceryCategoryId);
            if (groceryCategory is null) return false;

            _context.GroceryCategories.Remove(groceryCategory);
            return true;
        }

        public async Task<GetGroceryCategoryDto?> UpdateGroceryCategory(UpdateGroceryCategoryDto updatedGroceryCategory)
        {

            GroceryCategory? groceryCategory = await _context.GroceryCategories.FindAsync(updatedGroceryCategory.Id);
            if (groceryCategory is null) return null;
            _mapper.Map(updatedGroceryCategory, groceryCategory);
            return _mapper.Map<GetGroceryCategoryDto>(groceryCategory);
        }
    }
}
