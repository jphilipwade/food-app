using API.Dtos.Ingredient;
using API.Entities;

namespace API.Services;

public interface IIngredientService
{
    Task<ServiceResponse<IEnumerable<GetIngredientDto>>> GetAllIngredients();
    Task<ServiceResponse<GetIngredientDto>> CreateIngredient(AddIngredientDto addIngredientDto);
    Task<ServiceResponse<GetIngredientDto>> RetrieveIngredient(int id);
    Task<ServiceResponse<GetIngredientDto>> UpdateIngredient(UpdateIngredientDto updateIngredientDto);
    Task<ServiceResponse<GetIngredientDto>> DeleteIngredient(int id);
    Task<ServiceResponse<GetIngredientQuantityDto>> AddIngredientQuantity(AddIngredientQuantityDto addIngredientQuantityDto);
}