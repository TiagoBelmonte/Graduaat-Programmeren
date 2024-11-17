import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";

import { RouterProvider, createBrowserRouter } from "react-router-dom";
import App from "./App.jsx";
import RootLayout from "./navigation/RootLayout.jsx";
import DetailsPage from "./pages/DetailsPage.jsx";
import FavoritesPage from "./pages/FavoritesPage.jsx";
import FavoritesContextProvider from "./contexts/FavoritesContextProvider.jsx";

const browserRouter = createBrowserRouter([
  // TODO:  Maak hier verschillende routes aan, vergeet ook niet de RootLayout component
  //        De volgende paden moeten ondersteund worden:
  //          - "/"           -> Home pad moet leiden naar de App component
  //          - "/details/id" -> Details pad moet leiden naar de DetailsPage, LETOP: dynamische id dus bvb. details/14
  //          - "/favorites"  -> Favorites pad moet leiden naar de FavoritesPage
]);

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <FavoritesContextProvider>
      <RouterProvider router={browserRouter}></RouterProvider>
    </FavoritesContextProvider>
  </React.StrictMode>
);
