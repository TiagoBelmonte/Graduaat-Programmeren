import Axios from "axios";

const BASE_URL = "http://localhost:3000/categories";

export const getAllCategories = () => {
  // TODO: Gebruik de correcte Axios methode waar de X'en staan
  return Axios.get(`${BASE_URL}`, { withCredentials: true });
};

export const removeCategory = (id) => {
  // TODO: Gebruik de correcte Axios methode waar de X'en staan
  return Axios.delete(`${BASE_URL}/${id}`, { withCredentials: true });
};
