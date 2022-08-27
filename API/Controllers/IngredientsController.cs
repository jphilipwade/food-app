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
        return result.Success ? Ok(result) : StatusCode(result.StatusCode, new {Message = result.Message});
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<GetIngredientDto>>> AddIngredient(AddIngredientDto addIngredientDto)
    {
        var result = await _ingredientService.CreateIngredient(addIngredientDto);
        return result.Success ? Ok(result) : StatusCode(result.StatusCode, new {Message = result.Message});
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ServiceResponse<GetIngredientDto>>> GetIngredient(int id)
    {
        var result = await _ingredientService.RetrieveIngredient(id);
        return result.Success ? Ok(result) : StatusCode(result.StatusCode, new {Message = result.Message});
    }

    [HttpPost]
    [Route("quantity")]
    public async Task<ActionResult<ServiceResponse<GetIngredientQuantityDto>>> AddIngredientQuantity(
        AddIngredientQuantityDto addIngredientQuantityDto)
    {
        var result = await _ingredientService.AddIngredientQuantity(addIngredientQuantityDto);
        return result.Success ? Ok(result) : StatusCode(result.StatusCode, new {Message = result.Message});
    }
}