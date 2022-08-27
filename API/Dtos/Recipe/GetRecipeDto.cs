using API.Dtos.Ingredient;
using API.Entities;

namespace API.Dtos.Recipe;

public class GetRecipeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<GetIngredientQuantityDto> Ingredients { get; set; }
}