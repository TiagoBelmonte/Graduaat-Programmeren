import { useEffect, useState } from "react";
import { useFavorites } from "../hooks/useFavorites";
import Item from "../components/Item";

const FavoritesPage = () => {
  // TODO: Gebruik hier ook de favorites context aan de hand van uw eigen useFavorites hook.
  const { favorites } = useFavorites();

  // TODO: Maak een timeElapsed state waar je de state kan bijhouden van een soort timer.
  const [timeElapsed, setTimeElapsed] = useState(0);

  // TODO: Maak een timer die om de seconde de timeElapsed state verhoogt met 1 om deze te tonen verder op in de paragraaf.
  //       Opgelet dat dit steeds mooi wordt afgesloten. TIP: Maak gebruik van setInterval
  useEffect(() => {
    const timerId = setInterval(() => {
      setTimeElapsed((prevTime) => prevTime + 1);
    }, 1000);

    return () => clearInterval(timerId);
  }, []);

  return (
    <div className="flex-grow bg-food-yellow p-4">
      <div className="flex justify-between items-center">
        <h1 className="text-3xl text-white font-thin">Favorieten</h1>
        {/* TODO: Geef hier de waarde van de timeElapsed state weer */}
        <p className="text-xl text-white font-thin">
          Tijd verstreken: <span className="font-black">{timeElapsed}</span>
        </p>
      </div>

      {favorites.length ? (
        <div className="grid grid-cols-1 lg:grid-cols-2 xl:grid-cols-3 2xl:grid-cols-4 justify-items-center content-center gap-4">
          {/* TODO: Toon voor elke favoriet de Item component die je al eerder geïmplementeerd hebt (hergebruik van de home pagina) */}
          {favorites.map((f) => (
            <Item key={f.id} fruit={f} />
          ))}
        </div>
      ) : (
        // TODO: Toon een paragraaf met de volgende className "text-center uppercase font-thin"
        //       indien er geen favorieten zijn, met de tekst "Geen favorieten".
        <p className="text-center uppercase font-thin">Geen favorieten</p>
      )}
    </div>
  );
};

export default FavoritesPage;
