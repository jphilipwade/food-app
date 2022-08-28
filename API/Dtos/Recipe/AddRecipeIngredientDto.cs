namespace API.Dtos.Recipe;

public class AddRecipeIngredientDto
{
    public int RecipeId { get; set; }
    public int IngredientId { get; set; }
    public int Quantity { get; set; }
}