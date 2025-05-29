import React from "react";
import useAuth from "../contexts/AuthContextProvider";
import { useNavigate } from "react-router-dom";

const ProtectedRoute = () => {
  // TODO: Haal de user en de isLoading uit de useAuth hook
  const navigate = useNavigate();
  const { user, isLoading, props } = useAuth();
  // TODO: Als isLoading true is -> Geef dan een paragraaf terug met "Loading..."
  if (isLoading) {
    return <p>Loading...</p>;
  }
  // TODO: Als de user bestaat (dus niet null of undefined) geef dan de kind components vanuit de props terug,
  if (user != null) {
    return props.children;
  } else {
    navigate("login");
  }
  // zoniet navigeer dan naar de login pagina met de Navigate component - VERGEET niet de props binnen te krijgen
};

export default ProtectedRoute;
