import React from "react";
import error from "../assets/error.png";

const NotFoundPage = () => {
  return (
    <div>
      <h1>404</h1>
      <p>Niet gevonden!</p>
      <img src={error} />
    </div>
  );
};

export default NotFoundPage;
