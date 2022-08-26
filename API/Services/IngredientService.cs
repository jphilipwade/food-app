using API.Data;
using API.Dtos.Ingredient;
using API.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class IngredientService : IIngredientService
{
    private readonly IMapper _mapper;
    private readonly FoodAppContext _context;

    public IngredientService(IMapper mapper, FoodAppContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<ServiceResponse<IEnumerable<GetIngredientDto>>> GetAllIngredients()
    {
        var response = new ServiceResponse<IEnumerable<GetIngredientDto>>();

        try
        {
            var ingredients = await _context.Ingredients.ToListAsync();
            var data = ingredients.Select(i => _mapper.Map<GetIngredientDto>(i));
            response.Data = data;
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
        }

        return response;
    }
}