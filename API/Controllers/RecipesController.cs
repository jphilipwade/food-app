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
        return result.Success ? Ok(result) : StatusCode(result.StatusCode, new { Message = result.Message });
    }

    [HttpPost]
    [Route("ingredient")]
    public async Task<ActionResult<ServiceResponse<GetRecipeDto>>> AddRecipeIngredientQuantity(AddRecipeIngredientQuantityDto addRecipeIngredientQuantityDto)
    {
        var result = await _recipeService.CreateRecipeIngredientQuantity(addRecipeIngredientQuantityDto);
        return result.Success ? Ok(result) : StatusCode(result.StatusCode, new { Message = result.Message });
    }
}