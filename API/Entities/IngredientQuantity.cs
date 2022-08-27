namespace API.Entities;

public class IngredientQuantity
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public Ingredient Ingredient { get; set; }
}