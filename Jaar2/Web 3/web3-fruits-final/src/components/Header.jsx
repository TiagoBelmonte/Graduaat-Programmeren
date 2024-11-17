import { MdOutlineFavorite } from "react-icons/md";
import { NavLink } from "react-router-dom";

const Header = () => {
  return (
    <div className="bg-food-red text-white h-24 flex items-center justify-between px-4">
      <p className="text-3xl font-thin">Webfruits</p>
      {/* TODO: Maak hier een link naar de favorieten pagina, toon ook aan de gebruiker wanneer deze actief staat met de underline class */}
      <div className="flex gap-8">
        <NavLink
          className={({ isActive }) =>
            `${isActive ? "underline underline-offset-8" : "no-underline"}`
          }
          to="/">
          Home
        </NavLink>
        <NavLink
          className={({ isActive }) =>
            `${isActive ? "underline underline-offset-8" : "no-underline"}`
          }
          to="/favorites">
          Favorieten
        </NavLink>
      </div>
    </div>
  );
};

export default Header;
