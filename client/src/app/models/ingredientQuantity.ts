import { Ingredient } from "./ingredient";

export interface IngredientQuantity {
    id: number;
    quantity: number;
    ingredient: Ingredient;
}