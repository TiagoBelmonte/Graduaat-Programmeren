import React from "react";

//statische image importeren
import duneImg from "../assets/dune_poster.jpg";
const Movie = ({ movie }) => {
  return (
    <div className="shadow-lg rounded-lg overflow-clip">
      {/*Statische image*/}
      {/*<img src={duneImg} />*/}
      <img
        src={new URL(`../assets/${movie.poster_path}`, import.meta.url).href}
      />
      <div>
        <p className="font-bold min-h-10 text-center">{movie.title}</p>
        <p>{movie.genres.join(", ")}</p>
      </div>
    </div>
  );
};

export default Movie;
