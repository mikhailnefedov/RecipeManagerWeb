using AutoMapper;
using RecipeManagerWeb.Dtos;
using RecipeManagerWeb.Models;

namespace RecipeManagerWeb
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddGroceryItemDto, GroceryItem>();
            CreateMap<AddRecipeCategoryDto, RecipeCategory>();
            CreateMap<AddRecipeDto, Recipe>()
                .ForMember(dest => dest.Instructions, opt => opt.Ignore())
                .ForMember(dest => dest.Ingredients, opt => opt.Ignore());
            CreateMap<GroceryCategory, GetGroceryCategoryDto>();
            CreateMap<GroceryItem, GetGroceryItemDto>();

            CreateMap<Recipe, GetRecipeOverviewDto>();
            CreateMap<Recipe, GetRecipeDto>();
            CreateMap<InstructionStep, GetInstructionStepDto>();
            CreateMap<RecipeGroceryItem, GetRecipeGroceryItemDto>()
                .ForMember(dest => dest.GroceryName, opt => opt.MapFrom(src => src.GroceryItem.Name));
        }
    }
}
