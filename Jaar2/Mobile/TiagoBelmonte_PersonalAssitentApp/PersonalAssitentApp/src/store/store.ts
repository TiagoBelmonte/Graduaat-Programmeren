import { combineReducers, configureStore } from "@reduxjs/toolkit";
// (dia 134) configureStore en combineReducers uit Redux Toolkit

import { reducer as favoritesReducer } from "./favorites/slice";
import userReducer from "./userInfo/userSlice"; // (dia 134) eigen reducers importeren

import {
  FLUSH,
  PAUSE,
  PERSIST,
  PersistConfig,
  persistReducer,
  persistStore,
  PURGE,
  REGISTER,
  REHYDRATE,
} from "redux-persist"; // (dia 146) Redux Persist gebruiken voor AsyncStorage opslag

import AsyncStorage from "@react-native-async-storage/async-storage";
// (dia 137 + 146) AsyncStorage als mobiele variant van localStorage

const persistConfig = {
  key: "state", // 🔑 Staat wordt opgeslagen onder deze key
  storage: AsyncStorage, // (dia 146) Opslaan in mobiel toestel
};

const rootReducer = combineReducers({
  favorites: favoritesReducer,
  user: userReducer, // (dia 134–135) samengestelde rootReducer
});

const persistedReducer = persistReducer(persistConfig, rootReducer);
// (dia 146) persistReducer maakt rootReducer persistent

export const store = configureStore({
  reducer: persistedReducer,
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({
      serializableCheck: {
        ignoredActions: [PERSIST, FLUSH, REHYDRATE, PURGE, REGISTER, PAUSE],
        // (dia 147) Nodig om Redux Persist acties te negeren
      },
    }),
});

export const persistedStore = persistStore(store); // (dia 147) Opslag en rehydratie activeren

export type RootState = ReturnType<typeof store.getState>; // (dia 136) Handig type voor useSelector
export type AppDispatch = typeof store.dispatch; // (dia 136) Handig type voor useDispatch
