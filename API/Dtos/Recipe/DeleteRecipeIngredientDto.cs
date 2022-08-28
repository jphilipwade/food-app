namespace API.Dtos.Recipe;

public class DeleteRecipeIngredientDto
{
    public int RecipeId { get; set; }
    public int IngredientQuantityId { get; set; }
}