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


        public async Task<GroceryCategory> AddGroceryCategory(string categoryName)
        {
            GroceryCategory groceryCategory = new GroceryCategory { Name = categoryName};
            
            await _context.GroceryCategories.AddAsync(groceryCategory);
            await _context.SaveChangesAsync();

            return groceryCategory;
        }

        public async Task<GetGroceryCategoryDto?> GetGroceryCategory(int groceryCategoryId)
        {
            var groceryCategory = await _context.GroceryCategories.FindAsync(groceryCategoryId);

            if (groceryCategory is not null)
            {
                GetGroceryCategoryDto dto = _mapper.Map<GetGroceryCategoryDto>(groceryCategory);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<GetGroceryCategoryDto>> GetGroceryCategories()
        {
            var groceryCategories = await _context.GroceryCategories.ToListAsync();

            return groceryCategories.Select(c => _mapper.Map<GetGroceryCategoryDto>(c)).ToList();     
        }

        public async Task<bool> DeleteGroceryCategory(int groceryCategoryId)
        {
            try
            {
                var groceryCategory = await _context.GroceryCategories.FindAsync(groceryCategoryId);
                if (groceryCategory is null) return false;

                int relatedItemsCount = await _context.GroceryItems.Where(item => item.GroceryCategory == groceryCategory).CountAsync();

                if (relatedItemsCount == 0)
                {

                    _context.GroceryCategories.Remove(groceryCategory);
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

        public async Task<GetGroceryCategoryDto?> UpdateGroceryCategory(UpdateGroceryCategoryDto updatedGroceryCategory)
        {
            try
            {
                GroceryCategory? groceryCategory = await _context.GroceryCategories.FindAsync(updatedGroceryCategory.Id);

                _mapper.Map(updatedGroceryCategory, groceryCategory);

                await _context.SaveChangesAsync();

                return _mapper.Map<GetGroceryCategoryDto>(groceryCategory);
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
