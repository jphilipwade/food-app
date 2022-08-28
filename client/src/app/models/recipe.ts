import { IngredientQuantity } from "./ingredientQuantity";

export interface Recipe {
    id: number;
    name: string;
    description: string;
    ingredients?: IngredientQuantity[];
}
