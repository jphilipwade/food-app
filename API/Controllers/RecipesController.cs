using API.Dtos.Recipe;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class RecipesController : BaseApiController
{
    private readonly IRecipeService _recipeService;

    public RecipesController(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<IEnumerable<GetRecipeDto>>>> GetRecipes()
    {
        var result = await _recipeService.GetAllRecipes();
        return result.Success ? Ok(result) : StatusCode(result.StatusCode, new { result.Message });
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<GetRecipeDto>>> AddRecipe(AddRecipeDto addRecipeDto)
    {
        var result = await _recipeService.CreateRecipe(addRecipeDto);
        return result.Success ? Ok(result) : StatusCode(result.StatusCode, new { result.Message });
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<ServiceResponse<GetRecipeDto>>> GetRecipe(int id)
    {
        var result = await _recipeService.RetrieveRecipe(id);
        return result.Success ? Ok(result) : StatusCode(result.StatusCode, new { result.Message });
    }

    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<string>>> DeleteRecipe(int id)
    {
        var result = await _recipeService.DeleteRecipe(id);
        return result.Success ? NoContent() : StatusCode(result.StatusCode, new { result.Message });
    }
    
    [HttpPost]
    [Route("ingredients")]
    public async Task<ActionResult<ServiceResponse<GetRecipeDto>>> AddRecipeIngredientQuantity(AddRecipeIngredientDto addRecipeIngredientDto)
    {
        var result = await _recipeService.CreateRecipeIngredientQuantity(addRecipeIngredientDto);
        return result.Success ? Ok(result) : StatusCode(result.StatusCode, new { result.Message });

    }
    
    [HttpDelete]
    [Route("ingredients")]
    public async Task<ActionResult<ServiceResponse<GetRecipeDto>>> DeleteRecipeIngredientQuantity(DeleteRecipeIngredientDto deleteRecipeIngredientDto)
    {
        var result = await _recipeService.DeleteRecipeIngredientQuantity(deleteRecipeIngredientDto);
        return result.Success ? Ok(result) : StatusCode(result.StatusCode, new { result.Message });
    }
}