namespace API.Dtos.Ingredient;

public class GetIngredientQuantityDto
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public GetIngredientDto Ingredient { get; set; }
}