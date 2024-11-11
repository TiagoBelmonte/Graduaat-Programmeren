import React from "react";
import { useFavorites } from "../contexts/FavoritesContext";
import Movie from "../components/Movie";

const FavoritesPAge = () => {
  //context gebruiken
  const { favorites } = useFavorites();

  return (
    <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 2xl:grid-cols-5 gap-8 my-4 justify-items-center">
      {favorites.map((m) => {
        return <Movie key={m.id} movie={m} />;
      })}
    </div>
  );
};

export default FavoritesPAge;
