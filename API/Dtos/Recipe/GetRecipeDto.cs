using API.Dtos.Ingredient;

namespace API.Dtos.Recipe;

public class GetRecipeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<GetIngredientDto> Ingredients { get; set; }
}