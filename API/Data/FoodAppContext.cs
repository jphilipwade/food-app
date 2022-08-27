using System.Collections.Immutable;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class FoodAppContext : DbContext
{
    public FoodAppContext(DbContextOptions options):base(options) { }
    
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Recipe> Recipes { get; set; }

    public DbSet<IngredientQuantity> IngredientQuantities { get; set; }
}