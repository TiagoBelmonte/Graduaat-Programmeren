import React, { createContext, useContext, useState } from "react";
import { useEffect } from "react";
import authAPI from "../api/auth";
import { useNavigate } from "react-router-dom";
import { useVerifyUser } from "react";

const AuthContext = createContext();

const AuthContextProvider = (props) => {
  // TODO: Maak een user state aan - initieël null
  // TODO: Maak een isLoading state aan - initieël true
  const [user, setUser] = useState(null);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState(false);
  const navigate = useNavigate();
  const verifyUser = useVerifyUser();

  // TODO: Zorg dat deze code enkel uitgevoerd wordt bij het mounten van de component
  useEffect(() => {
    (async () => {
      try {
        const response = await verifyUser();
        setUser(response.data);
      } catch (error) {
        setUser(null);
      } finally {
        setIsLoading(true);
      }
    })();
  }, []);

  const login = async (email, password, navigate) => {
    // TODO: Implementatie login methode
    //  - Zet de isLoading state op true
    setIsLoading(true);
    //  - Gebruik de signIn methode vanuit het auth.js bestand uit de api map met email en password als parameters
    //  - Wacht op het resultaat en zet dit in de user state
    try {
      setUser(await authAPI.signIn(email, password));
    } catch (error) {
      setError(error);
    } finally {
      setIsLoading(false);
      setUser(null);
    }
    //  - Als de navigate die in deze methode binnen komt niet null / undefined is navigeer dan naar de homepagina
    // - Deze wordt vanuit een andere component meegegeven als argument
  };
  if (navigate != null) {
    navigate("/");
  }
  //  - Vergeet niet de foutenafhandeling -> Reset de user state met null

  //  - Uiteindelijk zet je de isLoading state terug op false

  const logout = async () => {
    // TODO: Implementatie logout methode
    //  - Gebruik de signOut methode vanuit het auth.js bestand uit de api map -> reset de user state met null
    try {
      authAPI.signOut();
    } catch (error) {
      setError(error);
    } finally {
      setUser(null);
      //  - Vergeet niet de foutenafhandeling
    }
  };
  const changePassword = async (newPassword) => {
    // TODO: Implementatie changePassword methode
    //  - Gebruik de resetPassword methode vanuit het auth.js bestand uit de api map met als parameter het newPassword
    try {
      authAPI.resetPassword(newPassword);
    } catch (error) {
      setError(error);
    }

    //  - Vergeet niet de foutenafhandeling
  };

  return (
    // TODO: Vul deze return aan zodanig dat de context gebruikt kan worden
    //  Zorg ervoor dat je de isLoading, user, login, logout en changePassword mee kunt geven
    //  OPGELET voor de kinder components die meegegeven kunnen worden vanuit de props

    <AuthContextProvider.Provider
      value={{
        user,
        isLoading,
        login,
        logout,
        changePassword,
        error,
      }}
    >
      {props.children}
    </AuthContextProvider.Provider>
  );
};
export default AuthContextProvider;

export const useAuth = () => useContext(AuthContext);
