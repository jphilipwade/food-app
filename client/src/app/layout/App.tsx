import { Typography } from "@mui/material";
import { useEffect, useState } from "react";
import Recipes from "../../features/recipe/Recipes";
import { Recipe } from "../models/recipe";

function App() {
  const [recipes, setRecipes] = useState<Recipe[]>([]);

  useEffect(() => {
    fetch("https://localhost:7267/api/Recipes")
      .then(response => response.json())
      .then(data => {
        setRecipes(data.data);
      })


  }, []);

  function addRecipe() {
    setRecipes(prevState => [...prevState, { id: 99, name: "milk", description: "milk" }])
  }

  return (
    <>
      <Typography variant="h1">Food App</Typography>
      <Recipes recipes={recipes} addRecipe={addRecipe} />

    </>
  );
}

export default App;
