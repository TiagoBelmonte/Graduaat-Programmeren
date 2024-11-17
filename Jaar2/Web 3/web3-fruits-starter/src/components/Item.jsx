import React from "react";

import { useNavigate } from "react-router-dom";
import { MdOutlineFavoriteBorder, MdOutlineFavorite } from "react-icons/md";
import { useFavorites } from "../hooks/useFavorites";

const Item = ({ fruit }) => {
  //
  const navigate = useNavigate();

  // TODO:  Maak gebruik van jouw useFavorites() hook die je moet implementeren
  //        Je zal hieruit de favorites en de addFavorite moeten uit destructuren

  // TODO:  Implementeer handleFavoriteClick
  //        Methode om een fruit object toe te voegen aan de favorites context,
  //        maak hiervoor gebruik van de addFavorite methode vanuit de useFavorites hook (die je zelf moet implementeren)'
  //        OPGELET: Stoppen van event bubbling
  const handleFavoriteClick = (event, fruit) => {};

  return (
    <div
      className="rounded-lg mt-8 overflow-clip hover:shadow-2xl cursor-pointer bg-food-orange relative"
      // TODO: Implementeer onClick -> Navigeren naar detail pagina met de correcte id
      onClick={null}>
      <img
        className="w-full min-w-96 h-56 object-contain hover:object-cover bg-white"
        // TODO: Vul het src attribuut in met de img property van het fruit object
      />
      <p className="text-center font-bold text-3xl my-6 text-amber-50">
        {/* TODO: Vul de naam van het fruit object hierin */}
      </p>
      <button
        className="p-2 rounded-full  absolute top-4 right-4 text-3xl text-food-red hover:bg-food-red hover:text-white"
        onClick={(event) => {
          handleFavoriteClick(event, fruit);
        }}>
        {/* TODO:   Checken of dit fruit al in de favorieten zit en op basis daarvan een ander icoon teruggeven
                    INDIEN JA toon dan <MdOutlineFavorite /> 
                    INDIEN NEEN toon dan <MdOutlineFavoriteBorder />
                    TIP: Je kan gebruik maken van de some() methode, of er minstens 1 element gelijk is aan een bepaalde voorwaarde
                    Je zal hiervoor de favorites context moeten gebruiken.
        */}
      </button>
    </div>
  );
};

export default Item;
