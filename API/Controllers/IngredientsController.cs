using API.Data;
using API.Dtos.Ingredient;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class IngredientsController : BaseApiController
{
    private readonly IIngredientService _ingredientService;
    private readonly FoodAppContext _context;

    public IngredientsController(IIngredientService ingredientService, FoodAppContext context)
    {
        _ingredientService = ingredientService;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<IEnumerable<GetIngredientDto>>>> GetIngredients()
    {
        var result = await _ingredientService.GetAllIngredients();

        if (result.Success)
        {
            return Ok(result);    
        }

        return StatusCode(StatusCodes.Status500InternalServerError, new {Message = result.Message});
    }

}