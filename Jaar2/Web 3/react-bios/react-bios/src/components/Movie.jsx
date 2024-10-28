import React from "react";

//statische image importeren
import duneImg from "../assets/dune_poster.jpg";
import { useNavigate } from "react-router-dom";
import { MdFavorite, MdOutlineFavorite } from "react-icons/md";
const Movie = ({ movie }) => {
  // Hook om te kunnen navigeren in JS code -> useNavigate();

  const navigate = useNavigate();

  const favorites = [];

  return (
    <div
      className="relative shadow-lg rounded-lg overflow-clip cursor-pointer transition duration-700 hover:scale-105"
      onClick={() => navigate(`/details/${movie.id}`)}
    >
      {/*Statische image*/}
      {/*<img src={duneImg} />*/}

      <button
        className="absolute top-4 right-4 rounded-full p-2 text-2xl text-emerald-300 bg-emerald-600"
        onClick={(event) => {
          favorites.push(movie);
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
