namespace API.Entities;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Size { get; set; }
    public List<Recipe> Recipes { get; set; }
}