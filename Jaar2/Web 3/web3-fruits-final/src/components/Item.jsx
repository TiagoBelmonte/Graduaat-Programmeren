import React from "react";
import { useNavigate } from "react-router-dom";

import { MdOutlineFavoriteBorder, MdOutlineFavorite } from "react-icons/md";
import { useFavorites } from "../hooks/useFavorites";

const Item = ({ fruit }) => {
  const navigate = useNavigate();
  const { favorites, addFavorite } = useFavorites();

  const handleFavoriteClick = (event, fruit) => {
    // Stoppen van event bubbling.
    addFavorite(fruit);
    event.stopPropagation();
  };

  return (
    <div
      className="rounded-lg mt-8 overflow-clip hover:shadow-2xl cursor-pointer bg-food-orange relative"
      onClick={() => navigate(`/details/${fruit.id}`)}
      key={fruit.id}>
      <img
        className="w-full min-w-96 h-56 object-contain hover:object-cover bg-white"
        src={`/images/${fruit.img}`}
      />
      <p className="text-center font-bold text-3xl my-6 text-amber-50">
        {fruit.name}
      </p>
      <button
        className="p-2 rounded-full  absolute top-4 right-4 text-3xl text-food-red hover:bg-food-red hover:text-white"
        onClick={(event) => {
          handleFavoriteClick(event, fruit);
        }}>
        {/* TODO: Checken of dit fruit al in de favorieten zit en op basis daarvan een ander icoon teruggeven */}
        {favorites.some((fav) => fav.id === fruit.id) ? (
          <MdOutlineFavorite />
        ) : (
          <MdOutlineFavoriteBorder />
        )}
      </button>
    </div>
  );
};

export default Item;
