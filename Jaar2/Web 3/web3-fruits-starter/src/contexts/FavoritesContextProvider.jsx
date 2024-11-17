import React, { createContext, useState, useEffect } from "react";

export const FavoritesContext = createContext();

const FavoritesContextProvider = (props) => {
  // Haal favorieten op uit sessionStorage (indien aanwezig) bij het starten van de applicatie
  const [favorites, setFavorites] = useState(() => {
    const storedFavorites = sessionStorage.getItem("favorites");
    return storedFavorites ? JSON.parse(storedFavorites) : [];
  });

  // Sla de favorieten op in sessionStorage telkens als de state verandert
  useEffect(() => {
    sessionStorage.setItem("favorites", JSON.stringify(favorites));
  }, [favorites]);

  // Voeg een favoriet toe (of verwijder als het al een favoriet is)
  const addFavorite = (fruit) => {
    const foundIdx = favorites.findIndex((f) => f.id === fruit.id);
    if (foundIdx === -1) {
      setFavorites([...favorites, fruit]);
    } else {
      removeFavorite(favorites[foundIdx].id);
    }
  };

  // Verwijder een favoriet op basis van id
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
