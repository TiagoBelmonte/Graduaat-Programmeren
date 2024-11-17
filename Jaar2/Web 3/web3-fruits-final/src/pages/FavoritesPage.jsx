// TODO: Implementeer FavoritesPage
import React, { useEffect, useState } from "react";
import { useFavorites } from "../hooks/useFavorites";
import Item from "../components/Item";

const FavoritesPage = () => {
  const { favorites } = useFavorites();
  const [timeElapsed, setTimeElapsed] = useState(0);

  useEffect(() => {
    const timerId = setInterval(() => {
      setTimeElapsed(timeElapsed + 1);
    }, 1000);

    return () => clearInterval(timerId);
  }, [timeElapsed]);

  return (
    <div className="flex-grow bg-food-yellow p-4">
      <div className="flex justify-between items-center">
        <h1 className="text-3xl text-white font-thin">Favorieten</h1>
        <p className="text-xl text-white font-thin">
          Tijd verstreken: <span className="font-black">{timeElapsed}</span>
        </p>
      </div>

      {favorites.length ? (
        <div className="grid grid-cols-1 lg:grid-cols-2 xl:grid-cols-3 2xl:grid-cols-4 justify-items-center content-center gap-4">
          {favorites.map((f) => (
            <Item key={f.id} fruit={f} />
          ))}
        </div>
      ) : (
        <p className="text-center uppercase font-thin">Geen favorieten</p>
      )}
    </div>
  );
};

export default FavoritesPage;
