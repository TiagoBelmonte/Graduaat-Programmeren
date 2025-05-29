import Axios from "axios";

const BASE_URL = "http://localhost:3000/transactions";

export const getAllTransactions = () => {
  // TODO: Gebruik de correcte Axios methode waar de X'en staan
  return Axios.get(`${BASE_URL}`, { withCredentials: true });
};

export const addTransaction = (type, amount, description, date, categoryId) => {
  // TODO: Gebruik de correcte Axios methode waar de X'en staan
  return Axios.post(
    `${BASE_URL}`,
    { type, amount, description, date, categoryId },
    { withCredentials: true }
  );
};
