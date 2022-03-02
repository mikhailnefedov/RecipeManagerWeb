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
            CreateMap<GroceryItem, GetGroceryItemDto>()
                .ForMember(dest => dest.groceryCategoryId, opt => opt.MapFrom(src => src.Category.Id))
                .ForMember(dest => dest.groceryCategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Recipe, GetRecipeOverviewDto>();
            CreateMap<Recipe, GetRecipeDto>();
            CreateMap<InstructionStep, GetInstructionStepDto>();
            CreateMap<RecipeGroceryItem, GetRecipeGroceryItemDto>()
                .ForMember(dest => dest.GroceryName, opt => opt.MapFrom(src => src.GroceryItem.Name));

            CreateMap<RecipeCategory, GetRecipeCategoryDto>();

            CreateMap<UpdateGroceryCategoryDto, GroceryCategory>();
            CreateMap<UpdateGroceryItemDto, GroceryItem>();
            CreateMap<UpdateRecipeCategoryDto, RecipeCategory>();
        }
    }
}
