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
                return response;
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

    public async Task<ServiceResponse<string>> DeleteRecipe(int id)
    {
        var response = new ServiceResponse<string>();

        try
        {
            var recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);
            
            if (recipe is null)
            {
                response.Success = false;
                response.Message = "Recipe not found";
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            response.StatusCode = StatusCodes.Status204NoContent;
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
        }
        
        return response;
    }
    
    public async Task<ServiceResponse<GetRecipeDto>> CreateRecipeIngredientQuantity(AddRecipeIngredientDto addRecipeIngredientDto)
    {
        var response = new ServiceResponse<GetRecipeDto>();

        try
        {
            var recipe = await _context.Recipes
                .Include(r => r.Ingredients)
                .ThenInclude(i => i.Ingredient)
                .FirstOrDefaultAsync(r => r.Id == addRecipeIngredientDto.RecipeId);
            
            if (recipe is null)
            {
                response.Success = false;
                response.Message = "Ingredient not found";
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }
            
            var ingredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == addRecipeIngredientDto.IngredientId);
            
            if (ingredient is null)
            {
                response.Success = false;
                response.Message = "Ingredient not found";
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            var newIngredientQuantity = _mapper.Map<IngredientQuantity>(addRecipeIngredientDto);
            newIngredientQuantity.Ingredient = ingredient;
            var ingredientQuantity = await _context.IngredientQuantities.AddAsync(newIngredientQuantity);
            recipe.Ingredients.Add(newIngredientQuantity);
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

    public async Task<ServiceResponse<GetRecipeDto>> DeleteRecipeIngredientQuantity(DeleteRecipeIngredientDto deleteRecipeIngredientDto)
    {
        var response = new ServiceResponse<GetRecipeDto>();

        try
        {
            var recipe = await _context.Recipes          
                .Include(r => r.Ingredients)
                .ThenInclude(i => i.Ingredient)
                .FirstOrDefaultAsync(r => r.Id == deleteRecipeIngredientDto.RecipeId);
            
            if (recipe is null)
            {
                response.Success = false;
                response.Message = "Recipe not found";
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            var ingredientQuantity = recipe.Ingredients.FirstOrDefault(i => i.Id == deleteRecipeIngredientDto.IngredientQuantityId);
            if (ingredientQuantity is null)
            {
                response.Success = false;
                response.Message = "IngredientQuantity not found";
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            recipe.Ingredients.Remove(ingredientQuantity);
            _context.IngredientQuantities.Remove(ingredientQuantity);
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