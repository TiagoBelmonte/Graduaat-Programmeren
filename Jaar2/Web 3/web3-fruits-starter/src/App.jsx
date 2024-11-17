import { useState } from "react";
import fruits from "./utils/fruits.json";

// Deze properties kunnen gebruikt worden om dynamisch de toggle buttons te maken,
// en alsook de property die gebruikt moet worden om op te sorteren
const SORT_PROPERTIES = [
  "calories",
  "fat",
  "sugar",
  "carbohydrates",
  "protein",
];

function App() {
  // TODO: Maak nieuwe state aan, om de sortOrder in te stellen -> keuze tussen volgende properties vanuit de sortProperties array
  // of vanuit de Object.keys(fruit.nutritions) methode - dynamischer

  // const [sortOrder, setSortOrder] = useState("calories");

  return (
    <div className="flex-grow bg-food-yellow p-4">
      <div className="w-full flex gap-4 justify-center my-4 flex-wrap">
        {/* TODO: Voeg dynamisch de knoppen toe aan de hand van de sortProperties array, 
            voor elke waarde in deze array maak je een nieuwe knop aan. Bij het klikken op deze knop
            moet de sortOrder state aangepast worden naar de nieuwe waarde.
            Voor de className van de button kan je het volgende gebruiken:

            BASIS styling:        "px-4 py-2 text-white rounded-md uppercase"

            CONDITIONELE styling op basis van geselecteerde property: 
                GESELECTEERD      "bg-food-dark-orange" 
                NIET GESELECTEERD "bg-food-yellow border border-food-dark-orange"
        */}
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-2 xl:grid-cols-3 2xl:grid-cols-4 justify-items-center content-center gap-4">
        {/* TODO: Sorteer de lijst met fruit soorten (TIP: sort() methode) 
            op basis van de sortOrder en toon deze dan via de Item component op het scherm.
            Vergeet niet het fruit object mee te geven als data voor de Item component.
        */}
      </div>
    </div>
  );
}

export default App;
