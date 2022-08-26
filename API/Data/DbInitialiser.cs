using API.Entities;

namespace API.Data;

public static class DbInitialiser
{
    public static async Task Initialise(FoodAppContext context)
    {
        if (context.Ingredients.Any())
        {
            return;
        }

        const string recipeName = "Demo Meal";
        
        // create and insert ingredients
        var ingredients = new List<Ingredient>
        {
            new()
            {
                Name = "Tomato Puree",
                Description = "Double concentrate tomato puree",
                Size = "200g"
            },
            new()
            {
                Name = "Chopped Tomatoes Can",
                Description = "Chopped Tomatoes Can",
                Size = "400g"
            },
            new()
            {
                Name = "Plain Flour",
                Description = "Plain Flour",
                Size = "1.5kg"
            }
        };
        await context.Ingredients.AddRangeAsync(ingredients);

        var foo = context.Ingredients.Select(i => i.Id);
        
        // create and insert recipe
        var recipe = new Recipe()
        {
            Name = recipeName,
            Description = "Just random ingredients"
        };

        await context.Recipes.AddAsync(recipe);
        
        // save changes
        await context.SaveChangesAsync();
        
        var dbIngredientIds = context.Ingredients.ToList();
        var dbRecipeId = context.Recipes.FirstOrDefault().Id;

      
        
        await context.SaveChangesAsync();
        // var recipeIngredients =  ingredients.Select(i => i.Id);





        // create and insert ingredients

        // create and insert recipe


    }
}