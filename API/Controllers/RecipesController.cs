using API.Data;
using API.Dtos.Recipe;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class RecipesController : BaseApiController
{
    private readonly IRecipeService _recipeService;
    private readonly FoodAppContext _context;

    public RecipesController(IRecipeService recipeService, FoodAppContext context)
    {
        _recipeService = recipeService;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<IEnumerable<GetRecipeDto>>>> GetRecipes()
    {
        var result = await _recipeService.GetAllRecipes();
        return Ok(result);
    }

    [HttpPost]
    [Route("ingredient")]
    public async Task<ActionResult<ServiceResponse<GetRecipeDto>>> AddRecipeIngredient(AddRecipeIngredientDto addRecipeIngredientDto)
    {
        var result = await _recipeService.AddRecipeIngredient(addRecipeIngredientDto);

        if (result.Success)
        {
            return Ok(result);    
        }

        return NotFound(result.Message);
    }
}