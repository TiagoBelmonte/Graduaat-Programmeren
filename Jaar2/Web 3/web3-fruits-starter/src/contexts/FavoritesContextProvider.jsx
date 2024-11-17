import React, { createContext, useState } from "react";

export const FavoritesContext = createContext();

// TODO:  EXTRA PUNTEN
//        Zorg ervoor dat de favorieten bewaard blijven ook bij het refreshen van de pagina.

const FavoritesContextProvider = (props) => {
  // TODO:  Maak een nieuwe state aan om da favorieten bij te houden

  // TODO:  Implementeer addFavorite
  //        Favoriet toevoegen enkel en alleen als deze er nog niet in staat. TIP: findIndex() retourneert -1 als niet gevonden
  //        Indien gevonden -> roep dan removeFavorite op met de id van het te verwijderen fruit (je hebt de index al gevonden)
  //        TIP: State aanpassen
  const addFavorite = (fruit) => {};

  // TODO:  Implementeer removeFavorite
  //        Favoriet verwijderen op basis van id.
  //        TIP: kan ook met filter(), state aanpassen
  const removeFavorite = (fruitId) => {};

  return (
    <FavoritesContext.Provider
    //  TODO:   Bij de value property niet vergeten een object mee te geven met de favorites en de addFavorite
    >
      {/* TODO: Mankeert er hier niets??? */}
    </FavoritesContext.Provider>
  );
};

export default FavoritesContextProvider;
