import { createContext, useContext, useState } from "react";

//Stap 1: aanmaken van een nieuwe context
export const DarkModeContext = createContext();

//Stap 2: Provider component aanmaken
const DarkmodeContextProvider = (props) => {
  const [isDarkMode, setIsDarkMode] = useState(false);

  return (
    <DarkModeContext.Provider
      value={{
        isDarkMode: isDarkMode,
      }}
    >
      {props.children}
    </DarkModeContext.Provider>
  );
};

export default DarkmodeContextProvider;

// Custom hook aangemaakt
export const useDarkMode = () => {
  return useContext(DarkModeContext);
};
