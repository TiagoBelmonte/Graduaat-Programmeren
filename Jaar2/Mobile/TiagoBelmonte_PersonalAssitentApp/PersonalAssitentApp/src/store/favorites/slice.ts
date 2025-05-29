import { createSlice, PayloadAction } from "@reduxjs/toolkit";
// (dia 133–134) createSlice maakt automatisch reducer + actions aan
import { City } from "../../navigation/types";
// (Type voor consistente data, zie ook dia 169 over types)

const initialState: City[] = [];
// (dia 134) De initiële state van onze slice: een lege lijst van favorieten

const favoritesSlice = createSlice({
  name: "favorites", // (dia 134) Unieke naam voor de slice
  initialState,
  reducers: {
    addFavorite: (state, action: PayloadAction<City>) => {
      const isInState = state.some((c) => c.name === action.payload.name);
      if (!isInState) {
        return [...state, action.payload]; // (immutabele update)
      }
      return state;
    },
    removeFavorite: (state, action: PayloadAction<string>) => {
      return state.filter((c) => c.name !== action.payload); // verwijder stad obv naam
    },
    clearAll: () => {
      return initialState; // reset naar lege lijst
    },
  },
});

export const {
  reducer,
  actions: { addFavorite, removeFavorite, clearAll },
} = favoritesSlice; // (dia 134–135) Exporteer reducer en acties
