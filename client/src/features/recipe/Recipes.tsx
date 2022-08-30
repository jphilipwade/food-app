import { Avatar, List, ListItem, ListItemAvatar, ListItemText } from "@mui/material";
import { Recipe } from "../../app/models/recipe"

interface Props {
    recipes: Recipe[];
    addRecipe: () => void;
}

export default function Recipes({ recipes, addRecipe }: Props) {
    return (
        <>
            <List>
                {recipes.map(recipe => (
                    <ListItem key={recipe.id}>
                        <ListItemAvatar>
                            <Avatar src={recipe.description} />
                        </ListItemAvatar>
                        <ListItemText>
                            {recipe.name} - {recipe.description}
                        </ListItemText>
                    </ListItem>
                ))}
            </List>
            <button onClick={addRecipe}>Add Product</button>
        </>
    )
}