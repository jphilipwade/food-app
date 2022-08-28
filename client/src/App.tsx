import { useEffect, useState } from "react";

function App() {
  const [products, setProducts] = useState([
    { name: "bread", description: "bread" },
    { name: "cheese", description: "cheese" }
  ]);

  useEffect(() => {
    fetch("https://localhost:7267/api/Recipes")
      .then(response => response.json())
      .then(data => {
        setProducts(data.data);
      })


  }, []);

  function addProduct() {
    setProducts(prevState => [...prevState, { name: "milk", description: "milk" }])
  }

  return (
    <div>
      <h1>Food App</h1>
      <ul>
        {products.map((item, index) => (
          <li key={index}>{item.name} - {item.description}</li>
        ))}
      </ul>
      <button onClick={addProduct}>Add Product</button>
    </div>
  );
}

export default App;
