import React, { createContext, useState } from "react";

export const FavoritesContext = createContext();

const FavoritesContextProvider = (props) => {
  // TODO: Maak een nieuwe state aan om da favorieten bij te houden
  const [favorites, setFavorites] = useState([]);

  // TODO: Implementeer addFavorite
  //         Favoriet toevoegen enkel en alleen als deze er nog niet in staat. TIP: findIndex() retourneert -1 als niet gevonden
  const addFavorite = (fruit) => {
    const foundIdx = favorites.findIndex((f) => f.id === fruit.id);
    if (foundIdx === -1) {
      setFavorites([...favorites, fruit]);
    } else {
      removeFavorite(favorites[foundIdx].id);
    }
  };

  // TODO: Implementeer removeFavorite
  //         Favoriet verwijderen op basis van id. TIP: kan ook met filter()
  const removeFavorite = (fruitId) => {
    setFavorites(favorites.filter((f) => f.id !== fruitId));
  };

  return (
    <FavoritesContext.Provider
      value={{ favorites, addFavorite, removeFavorite }}
    >
      {props.children}
    </FavoritesContext.Provider>
  );
};

export default FavoritesContextProvider;
