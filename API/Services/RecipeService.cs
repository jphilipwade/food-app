using API.Data;
using API.Dtos.Recipe;
using API.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class RecipeService : IRecipeService
{
    private readonly IMapper _mapper;
    private readonly FoodAppContext _context;

    public RecipeService(IMapper mapper, FoodAppContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<ServiceResponse<IEnumerable<GetRecipeDto>>> GetAllRecipes()
    {
        var response = new ServiceResponse<IEnumerable<GetRecipeDto>>();

        try
        {
            var recipes = await _context.Recipes.Include(r => r.Ingredients).ToListAsync();
            var data = recipes.Select(r => _mapper.Map<GetRecipeDto>(r));
            response.Data = data;
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
        }
        
        return response;
    }

    public async Task<ServiceResponse<GetRecipeDto>> AddRecipeIngredient(AddRecipeIngredientDto addRecipeIngredientDto)
    {
        var response = new ServiceResponse<GetRecipeDto>();

        try
        {
            var recipe = await _context.Recipes
                .Include(r => r.Ingredients)
                .FirstOrDefaultAsync(r => r.Id == addRecipeIngredientDto.RecipeId);

            if (recipe is null)
            {
                response.Success = false;
                response.Message = "Recipe not found";
                return response;
            }

            var ingredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == addRecipeIngredientDto.IngredientId);
            
            if (ingredient is null)
            {
                response.Success = false;
                response.Message = "Ingredient not found";
                return response;
            }
            
            recipe.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetRecipeDto>(recipe);
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
        }
        return response;
    }
}