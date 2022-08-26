using API.Dtos.Ingredient;
using API.Entities;

namespace API.Services;

public interface IIngredientService
{
    Task<ServiceResponse<IEnumerable<GetIngredientDto>>> GetAllIngredients();
    
    // TODO: CRUD
}