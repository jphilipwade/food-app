using API.Dtos.Ingredient;
using API.Dtos.Recipe;
using API.Entities;

namespace API.Services;

public interface IRecipeService
{
    Task<ServiceResponse<IEnumerable<GetRecipeDto>>> GetAllRecipes();
    
    Task<ServiceResponse<GetRecipeDto>> CreateRecipe(AddRecipeDto addRecipeDto);
    Task<ServiceResponse<GetRecipeDto>> RetrieveRecipe(int id);

    Task<ServiceResponse<GetRecipeDto>> CreateRecipeIngredientQuantity(AddRecipeIngredientQuantityDto addRecipeIngredientQuantityDto);
    // TODO: CRUD
}