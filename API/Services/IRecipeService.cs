using API.Dtos.Ingredient;
using API.Dtos.Recipe;
using API.Entities;

namespace API.Services;

public interface IRecipeService
{
    Task<ServiceResponse<IEnumerable<GetRecipeDto>>> GetAllRecipes();

    // TODO: CRUD
    
    Task<ServiceResponse<GetRecipeDto>> CreateRecipeIngredientQuantity(AddRecipeIngredientQuantityDto addRecipeIngredientQuantityDto);
    // TODO: CRUD
}