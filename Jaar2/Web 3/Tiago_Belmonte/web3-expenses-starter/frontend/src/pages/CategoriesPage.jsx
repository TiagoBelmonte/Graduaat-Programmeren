import { React, useState, useEffect } from "react";
import TitleLabel from "../components/TitleLabel";
import api from "../api/transactions";
import Axios from "axios";
import CategoryItem from "../components/CategoryItem";

const CategoriesPage = () => {
  // TODO: Maak een categories state aan - initieël lege array
  const [categories, setCategories] = useState([]);

  // TODO:  Gebruik de getAllCategories methode en steek dit in de juiste structuur zodanig dat deze code enkel uitvoert bij het mounten van de component
  //        Steek het resultaat van de getAllCategories in de categories state - TIP Axios response
  //        Vergeet geen foutenafhandeling toe te passen - dit mag in de console gelogd worden
  useEffect(() => {
    (async () => {
      try {
        const response = await Axios.get(api.getAllCategories);
        setCategories(response.data);
      } catch (error) {
        console.error(error);
      }
    })();
  }, []);

  return (
    <div>
      <TitleLabel>Categorieën</TitleLabel>
      {/* TODO: Voor elke category in de categories array toon dan de CategoryItem component met de category als prop die je meegeeft */}
      {categories.map((c) => (
        <option key={c.id} value={c.id}>
          <CategoryItem c />
        </option>
      ))}
    </div>
  );
};

export default CategoriesPage;
