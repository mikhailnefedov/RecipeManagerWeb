using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecipeManagerWeb.Data;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb.Repositories
{
    public class GroceryItemRepository : IGroceryItemRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public GroceryItemRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetGroceryItemDto> AddGroceryItem(AddGroceryItemDto newGroceryItem)
        {
            GroceryItem groceryItem = _mapper.Map<GroceryItem>(newGroceryItem);

            await _context.GroceryItems.AddAsync(groceryItem);
            return _mapper.Map<GetGroceryItemDto>(groceryItem);
        }

        public async Task<GetGroceryItemDto?> GetGroceryItem(int groceryItemId)
        {
            var groceryItem = await _context.GroceryItems.Include(item => item.GroceryCategory)
                .FirstAsync(item => item.Id == groceryItemId);
            return groceryItem != null ? _mapper.Map<GetGroceryItemDto>(groceryItem) : null;
        }

        public async Task<List<GetGroceryItemDto>> GetGroceryItems()
        {
            var groceryItems = await _context.GroceryItems.Include(item => item.GroceryCategory)
                .ToListAsync();
            return groceryItems.Select(item => _mapper.Map<GetGroceryItemDto>(item)).ToList();
        }

        public async Task<bool> DeleteGroceryItem(int groceryItemId)
        {

            var groceryItem = await _context.GroceryItems.FindAsync(groceryItemId);
            if (groceryItem is null) return false;

            bool usedInRecipes = await _context.RecipeGroceryItems.AnyAsync(item => item.GroceryItemId == groceryItemId);

            if (usedInRecipes)
            {
                return false;
            }
            else
            {
                _context.GroceryItems.Remove(groceryItem);
                return true;
            }
        }

        public async Task<GetGroceryItemDto?> UpdateGroceryItem(UpdateGroceryItemDto updatedGroceryItem)
        {
            GroceryItem? groceryItem = await _context.GroceryItems.FindAsync(updatedGroceryItem.Id);
            if (groceryItem is null) return null;
            _mapper.Map(updatedGroceryItem, groceryItem);
            return _mapper.Map<GetGroceryItemDto>(groceryItem);
        }
    }
}
