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

        public async Task<GroceryItem> AddGroceryItem(AddGroceryItemDto newGroceryItem)
        {
            GroceryItem groceryItem = _mapper.Map<GroceryItem>(newGroceryItem);
            groceryItem.Category = await _context.GroceryCategories.FirstAsync(c => c.Id == newGroceryItem.GroceryCategoryId);

            await _context.GroceryItems.AddAsync(groceryItem);
            await _context.SaveChangesAsync();

            return groceryItem;
        }

        public async Task<GetGroceryItemDto?> GetGroceryItem(int groceryItemId)
        {
            var groceryItem = await _context.GroceryItems.Include(item => item.Category)
                .FirstAsync(item => item.Id == groceryItemId);

            if (groceryItem is not null)
            {
                GetGroceryItemDto dto = _mapper.Map<GetGroceryItemDto>(groceryItem);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<GetGroceryItemDto>> GetGroceryItems()
        {
            var groceryItems = await _context.GroceryItems.Include(item => item.Category)
                .ToListAsync();

            return groceryItems.Select(item => _mapper.Map<GetGroceryItemDto>(item)).ToList();
        }
    }
}
