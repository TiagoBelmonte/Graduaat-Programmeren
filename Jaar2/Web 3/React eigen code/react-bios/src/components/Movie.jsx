import React from "react";

//statische image importeren
import duneImg from "../assets/dune_poster.jpg";
import { useNavigate } from "react-router-dom";
import { MdFavorite, MdOutlineFavorite } from "react-icons/md";
import FavoritesContextProvider, {
  useFavorites,
} from "../contexts/FavoritesContext";
import Button from "./Button";
const Movie = ({ movie }) => {
  // Hook om te kunnen navigeren in JS code -> useNavigate();

  const navigate = useNavigate();

  const { favorites, toggleFavorite } = useFavorites();

  const isInFavorite = favorites.some((f) => f.id === movie.id);

  return (
    <div
      className="relative shadow-lg rounded-lg overflow-clip cursor-pointer transition duration-700 hover:scale-105"
      onClick={() => navigate(`/details/${movie.id}`)}
    >
      {/*Statische image*/}
      {/*<img src={duneImg} />*/}

      <button
        className={`absolute top-4 right-4 rounded-full p-2 text-2xl bg-emerald-600 ${
          isInFavorite ? "text-red-500" : "text-emerald-300"
        }`}
        onClick={(event) => {
          toggleFavorite(movie);
          event.stopPropagation();
        }}
      >
        <MdOutlineFavorite />
      </button>
      <img
        src={new URL(`../assets/${movie.poster_path}`, import.meta.url).href}
      />
      <div className="min-h-36">
        <p className="font-bold text-center">{movie.title}</p>
        <p>{movie.genres.join(", ")}</p>
      </div>
    </div>
  );
};

export default Movie;
