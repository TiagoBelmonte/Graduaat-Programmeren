import { useNavigate } from "react-router-dom";
import { MdHome, MdLogout } from "react-icons/md";

const Header = () => {
  const navigate = useNavigate();

  const handleLogout = () => {
    // Session storage legen
    sessionStorage.clear();
    // Eventueel localStorage legen (indien gebruikt)
    localStorage.clear();
    // Navigeren naar de loginpagina
    navigate("/");
  };

  return (
    <div className="bg-cyan-700 p-4 flex justify-between items-center">
      {/* Logo kan hier worden toegevoegd indien gewenst */}
      {/* <img className="w-24" src={logo} alt="Logo" /> */}

      <div className="flex items-center gap-8 mr-4 text-2xl">
        {/* Button om terug te navigeren */}
        <button
          onClick={() => navigate(-1)}
          className="text-cyan-950 hover:text-white underline underline-offset-4"
          aria-label="Ga terug"
        >
          <MdHome />
        </button>

        {/* Button om uit te loggen */}
        <button
          onClick={handleLogout}
          className="text-cyan-950 hover:text-white underline underline-offset-4 flex items-center gap-2"
          aria-label="Log uit"
        >
          <MdLogout />
        </button>
      </div>
    </div>
  );
};

export default Header;
