const Header = () => {
  return (
    <div className="bg-food-red text-white h-24 flex items-center justify-between px-4">
      <p className="text-3xl font-thin">Webfruits</p>

      <div className="flex gap-8">
        {/* TODO: Maak hier een link naar de home pagina, toon ook aan de gebruiker wanneer deze actief staat met de underline class
                  De classname die je kan gebruiken wanneer deze active staat is "underline underline-offset-8" 
                  als deze niet active staat mag je gewoon "no-underline" gebruiken
      */}
        {/* TODO: Maak hier een link naar de favorieten pagina, toon ook aan de gebruiker wanneer deze actief staat met de underline class
                  De classname die je kan gebruiken wanneer deze active staat is "underline underline-offset-8" 
                  als deze niet active staat mag je gewoon "no-underline" gebruiken
        */}
      </div>
    </div>
  );
};

export default Header;
