import fruits from "./utils/fruits.json";
import { useState } from "react";
import Item from "./components/Item";

// Op deze properties kan gesorteerd worden.
const sortProperties = ["calories", "fat", "sugar", "carbohydrates", "protein"];

function App() {
  // TODO: Maak nieuwe state aan, om de sortOrder in te stellen -> keuze tussen volgende properties vanuit de sortProperties array
  // of vanuit de Object.keys(fruit.nutritions) methode - dynamischer
  const [sortOrder, setSortOrder] = useState("fat");

  return (
    <div className="flex-grow bg-food-yellow p-4">
      <div className="w-full flex gap-4 justify-center my-4 flex-wrap">
        {sortProperties.map((p) => (
          <button
            onClick={() => setSortOrder(p)}
            className={`px-4 py-2 text-white rounded-md uppercase ${
              sortOrder === p
                ? "bg-food-dark-orange"
                : "bg-food-yellow border border-food-dark-orange"
            }`}
            key={p}>
            {p}
          </button>
        ))}
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-2 xl:grid-cols-3 2xl:grid-cols-4 justify-items-center content-center gap-4">
        {fruits
          .sort((a, b) => a.nutritions[sortOrder] - b.nutritions[sortOrder])
          .map((f) => {
            return <Item key={f.id} fruit={f} />;
          })}
      </div>
    </div>
  );
}

export default App;
