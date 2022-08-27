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
            var recipes = await _context.Recipes
                .Include(r => r.Ingredients)
                .ThenInclude(i => i.Ingredient)
                .ToListAsync();
            
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

    public async Task<ServiceResponse<GetRecipeDto>> CreateRecipe(AddRecipeDto addRecipeDto)
    {
        var response = new ServiceResponse<GetRecipeDto>();

        try
        {
            var newRecipe = _mapper.Map<Recipe>(addRecipeDto);
            await _context.Recipes.AddAsync(newRecipe);
            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetRecipeDto>(newRecipe);
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
        }
        
        return response;
    }

    public async Task<ServiceResponse<GetRecipeDto>> RetrieveRecipe(int id)
    {
        var response = new ServiceResponse<GetRecipeDto>();
        
        try
        {
            var recipe = await _context.Recipes
                .Include(r => r.Ingredients)
                .ThenInclude(i => i.Ingredient)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe is null)
            {
                response.Success = false;
                response.Message = "Recipe not found";
                response.StatusCode = StatusCodes.Status404NotFound;
            }

            response.Data = _mapper.Map<GetRecipeDto>(recipe);
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
        }
        
        return response;
    }

    public async Task<ServiceResponse<DeleteRecipeDto>> DeleteRecipe(int id)
    {
        var response = new ServiceResponse<DeleteRecipeDto>();

        return response;
    }

    public async Task<ServiceResponse<GetRecipeDto>> CreateRecipeIngredientQuantity(AddRecipeIngredientQuantityDto addRecipeIngredientQuantityDto)
    {
        var response = new ServiceResponse<GetRecipeDto>();

        try
        {
            var recipe = await _context.Recipes
                .Include(r => r.Ingredients)
                .FirstOrDefaultAsync(r => r.Id == addRecipeIngredientQuantityDto.RecipeId);
            
            if (recipe is null)
            {
                response.Success = false;
                response.Message = "Recipe not found";
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }
            
            var ingredientQuantity = await _context.IngredientQuantities
                .Include(i=>i.Ingredient)
                .FirstOrDefaultAsync(i => i.Id == addRecipeIngredientQuantityDto.IngredientQuantityId);
            
            if (ingredientQuantity is null)
            {
                response.Success = false;
                response.Message = "Ingredient quantity not found";
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }
            
            recipe.Ingredients.Add(ingredientQuantity);
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