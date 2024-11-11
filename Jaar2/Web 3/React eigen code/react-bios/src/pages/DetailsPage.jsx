import React from "react";
import { useParams } from "react-router-dom";
import movies from "../utils/films.json";

const DetailsPage = () => {
  // ID komt vanuit de parameters vanuit onze router
  const { id } = useParams();
  // id omzetten naar int
  const idint = parseInt(id);
  //film gaan opzoeken
  let film = movies.find((Movie) => Movie.id === idint);
  //kijken of film met die id bestaat of niet
  if (film === undefined) {
    return <p>Geen film gevonden!</p>;
  }
  return (
    <div>
      <h1>{film.title}</h1>
    </div>
  );
};

export default DetailsPage;
