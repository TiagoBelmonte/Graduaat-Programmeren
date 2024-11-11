import { Button } from "@mui/material";
import React, { useEffect, useState } from "react";
import Axios from "axios";
import { useQuery } from "@tanstack/react-query";

const StarWarsPage = () => {
  //1ste methode -> fetch api
  // GET Request

  const [films, setFilms] = useState([]);
  const [IsLoading, setIsLoading] = useState(false);
  const [Error, setError] = useState();

  //met de FETCH API
  const fetchMovies = async () => {
    setIsLoading(true);
    try {
      const response = await fetch("https://swapi.dev/api/films");
      const responseData = await response.json();
      setFilms(responseData.results);
    } catch (error) {
      console.log(error);
      setError(error);
    } finally {
      setIsLoading(false);
    }
  };

  const fetchWithAxios = async () => {
    setIsLoading(true);
    try {
      const response = await Axios.get("https://swapi.dev/api/films");
      setFilms(response.data.results);
    } catch (error) {
      setError(error);
    } finally {
      setIsLoading(false);
    }
  };

  // useEffect(() => {
  //   //fetchMovies();
  //   fetchWithAxios();
  // }, []);
  //Lege array zorgt ervoor dat de fetchmovies maar 1x word uitgevoerd, enkel bij het inladen van de pagina

  //   useEffect(() => {
  //     async() => {
  //     setIsLoading(true);
  //     try {
  //       const response = await Axios.get("https://swapi.dev/api/films");
  //       setFilms(response.data.results);
  //     } catch (error) {
  //       setError(error);
  //     } finally {
  //       setIsLoading(false);
  //     }
  //   }();
  // },[]);

  const { data, isLoading, error, isError } = useQuery({
    queryKey: ["fetchMovies"],
    queryFn: () => {
      Axios.get("https://swapi.dev/api/films");
    },
  });

  if (isLoading) {
    return <p>Loading...</p>;
  }

  if (isError) {
    return (
      <div>
        <p>{JSON.stringify(error)}</p>
        <Button
          onClick={() => {
            fetchMovies;
          }}
        >
          Ververs pagina
        </Button>
      </div>
    );
  }

  return (
    <div>
      {films.map((f) => (
        <p key={f.episode_id}>{f.title}</p>
      ))}
    </div>
  );
};

export default StarWarsPage;
