// TODO: Implementeer de useFavorites hook - dat hij de context gebruikt

import { useContext } from "react";
import { FavoritesContext } from "../contexts/FavoritesContextProvider";

export const useFavorites = () => {
  return useContext(FavoritesContext);
};
