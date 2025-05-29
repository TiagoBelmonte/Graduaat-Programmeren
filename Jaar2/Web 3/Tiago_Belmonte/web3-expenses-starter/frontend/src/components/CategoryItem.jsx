import React from "react";
import { MdRemoveCircleOutline } from "react-icons/md";
import api from "../api/categories";
import { useNavigate } from "react-router-dom";

const CategoryItem = (props) => {
  // TODO: Haal de category uit de props
  // TODO: Gebruik de gepaste hook om te navigeren
  const categorie = props.children;
  const navigate = useNavigate();

  return (
    <div className="p-4 bg-zinc-900 my-4 rounded-lg flex justify-between items-center">
      <p className="text-white font-bold text-xl">
        {
          // TODO: Laat de name vanuit de category zien
          categorie.name
        }
      </p>

      <button
        onClick={
          // TODO: Implementeer de onClick methode
          //  - Roep de removeCategory methode en geef de id vanuit het category object mee als parameter
          api.removeCategory(categorie.id)
          //  - Roep de navigate methode op met 0 als parameter - Refresh van de pagina
          //geen idee waarom dit niet werkt
          //navigate("/categories",0)
        }
      >
        <MdRemoveCircleOutline className="text-2xl text-red-500" />
      </button>
    </div>
  );
};

export default CategoryItem;
