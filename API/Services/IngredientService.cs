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
            response.StatusCode = StatusCodes.Status500InternalServerError;
        }

        return response;
    }

    public async Task<ServiceResponse<GetIngredientDto>> CreateIngredient(AddIngredientDto addIngredientDto)
    {
        var response = new ServiceResponse<GetIngredientDto>();

        try
        {
            var newIngredient = _mapper.Map<Ingredient>(addIngredientDto);
            await _context.Ingredients.AddAsync(newIngredient);
            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetIngredientDto>(newIngredient);
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
            response.StatusCode = StatusCodes.Status500InternalServerError;
        }
        
        return response;
    }

    public async Task<ServiceResponse<GetIngredientDto>> RetrieveIngredient(int id)
    {
        var response = new ServiceResponse<GetIngredientDto>();

        try
        {
            var ingredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == id);

            if (ingredient is null)
            {
                response.Success = false;
                response.Message = "Ingredient not found";
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            response.Data = _mapper.Map<GetIngredientDto>(ingredient);
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
        }
        
        return response;
    }

    public async Task<ServiceResponse<GetIngredientDto>> UpdateIngredient(UpdateIngredientDto updateIngredientDto)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<GetIngredientDto>> DeleteIngredient(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<GetIngredientQuantityDto>> AddIngredientQuantity(AddIngredientQuantityDto addIngredientQuantityDto)
    {
        var response = new ServiceResponse<GetIngredientQuantityDto>();

        try
        {
            var ingredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == addIngredientQuantityDto.IngredientId);

            if (ingredient is null)
            {
                response.Success = false;
                response.Message = "Ingredient not found";
                response.StatusCode = StatusCodes.Status404NotFound;
                return response;
            }

            var newIngredientQuantity = _mapper.Map<IngredientQuantity>(addIngredientQuantityDto);
            newIngredientQuantity.Ingredient = ingredient;
            await _context.IngredientQuantities.AddAsync(newIngredientQuantity);
            await _context.SaveChangesAsync();
            response.Data = _mapper.Map<GetIngredientQuantityDto>(newIngredientQuantity);
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = e.Message;
        }

        return response;
    }
}