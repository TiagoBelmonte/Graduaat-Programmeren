// TODO: Implementeer de useFavorites hook - dat hij de context gebruikt
// TODO: Gebruik de context met de useContext hook, en geef hier de juiste context mee, retourneer deze in deze hook
import { useContext } from "react";
import { FavoritesContext } from "../contexts/FavoritesContextProvider";

export const useFavorites = () => {
  return useContext(FavoritesContext);
};
