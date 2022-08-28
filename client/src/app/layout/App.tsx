import { useEffect, useState } from "react";
import { Recipe } from "../models/recipe";

function App() {
  const [products, setRecipes] = useState<Recipe[]>([]);

  useEffect(() => {
    fetch("https://localhost:7267/api/Recipes")
      .then(response => response.json())
      .then(data => {
        setRecipes(data.data);
      })


  }, []);

  function addProduct() {
    setRecipes(prevState => [...prevState, { id: 99, name: "milk", description: "milk" }])
  }

  return (
    <div>
      <h1>Food App</h1>
      <ul>
        {products.map(recipe => (
          <li key={recipe.id}>{recipe.name} - {recipe.description}</li>
        ))}
      </ul>
      <button onClick={addProduct}>Add Product</button>
    </div>
  );
}

export default App;
