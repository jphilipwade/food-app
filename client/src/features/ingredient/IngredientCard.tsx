import { Ingredient } from "../../app/models/ingredient";

export default function IngredientCard(ingredient: Ingredient) {
    return (
        <>
            <h1>{ingredient.name}</h1>
            <h2>{ingredient.description}</h2>
        </>
    )
}