import Axios from "axios";

const BASE_URL = "http://localhost:3000";

export const signIn = (email, password) => {
  // TODO: Gebruik de correcte Axios methode waar de X'en staan
  return Axios.get(
    `${BASE_URL}/login`,
    { email, password },
    { withCredentials: true }
  );
};

export const verifyUser = () => {
  // TODO: Gebruik de correcte Axios methode waar de X'en staan
  return Axios.get(`${BASE_URL}/verify`, { withCredentials: true });
};

export const resetPassword = (password) => {
  // TODO: Gebruik de correcte Axios methode waar de X'en staan
  return Axios.patch(
    `${BASE_URL}/password`,
    { password },
    { withCredentials: true }
  );
};

export const signOut = () => {
  // TODO: Gebruik de correcte Axios methode waar de X'en staan
  return Axios.get(`${BASE_URL}/logout`, { withCredentials: true });
};
