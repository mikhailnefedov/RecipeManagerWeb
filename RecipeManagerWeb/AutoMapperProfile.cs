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
            CreateMap<AddGroceryCategoryDto, GroceryCategory>();
            CreateMap<AddRecipeCategoryDto, RecipeCategory>();
            CreateMap<AddRecipeDto, Recipe>();
            CreateMap<AddRecipeGroceryItemDto, RecipeGroceryItem>();
            CreateMap<AddInstructionStepDto, InstructionStep>();

            CreateMap<GroceryCategory, GetGroceryCategoryDto>();
            CreateMap<GroceryItem, GetGroceryItemDto>()
                .ForMember(dest => dest.groceryCategoryId, opt => opt.MapFrom(src => src.GroceryCategory.Id))
                .ForMember(dest => dest.groceryCategoryName, opt => opt.MapFrom(src => src.GroceryCategory.Name));

            CreateMap<Recipe, GetSmallRecipeDto>();
            CreateMap<Recipe, GetRecipeDto>();
            CreateMap<InstructionStep, GetInstructionStepDto>();
            CreateMap<RecipeGroceryItem, GetRecipeGroceryItemDto>()
                .ForMember(dest => dest.GroceryName, opt => opt.MapFrom(src => src.GroceryItem.Name));

            CreateMap<RecipeCategory, GetRecipeCategoryDto>();

            CreateMap<UpdateGroceryCategoryDto, GroceryCategory>();
            CreateMap<UpdateGroceryItemDto, GroceryItem>();
            CreateMap<UpdateRecipeCategoryDto, RecipeCategory>();
            CreateMap<UpdateRecipeDto, Recipe>();
            CreateMap<UpdateRecipeGroceryItemDto, RecipeGroceryItem>();
            CreateMap<UpdateInstructionStepDto, InstructionStep>();
        }
    }
}
