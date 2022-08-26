using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Ingredient;

public class AddIngredientDto
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public string Size { get; set; }
}