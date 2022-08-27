using API.Dtos.Ingredient;
using API.Dtos.Recipe;
using API.Entities;
using AutoMapper;

namespace API;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<Ingredient, GetIngredientDto>();
        CreateMap<AddRecipeDto, Recipe>();
        
        CreateMap<Recipe, GetRecipeDto>();
        CreateMap<AddIngredientDto, Ingredient>();

        CreateMap<AddIngredientQuantityDto, IngredientQuantity>();
        CreateMap<IngredientQuantity, GetIngredientQuantityDto>();
    }
}