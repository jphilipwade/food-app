import { Recipe } from "../../app/models/recipe"

interface Props {
    recipes: Recipe[];
    addRecipe: () => void;
}

export default function Recipes({ recipes, addRecipe }: Props) {
    return (
        <>
            <ul>
                {recipes.map(recipe => (
                    <li key={recipe.id}>{recipe.name} - {recipe.description} - {recipe.ingredients?.map(i => i.ingredient.name)}</li>
                ))}
            </ul>
            <button onClick={addRecipe}>Add Product</button>
        </>
    )
}