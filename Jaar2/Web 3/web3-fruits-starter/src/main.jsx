import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";

import { RouterProvider, createBrowserRouter } from "react-router-dom";
import App from "./App.jsx";
import RootLayout from "./navigation/RootLayout.jsx";
import DetailsPage from "./pages/DetailsPage.jsx";
import FavoritesPage from "./pages/FavoritesPage.jsx";
import FavoritesContextProvider from "./contexts/FavoritesContextProvider.jsx";

// TODO: Maak hier verschillende routes aan, vergeet ook niet de RootLayout component
//        De volgende paden moeten ondersteund worden:
//          - "/"           -> Home pad moet leiden naar de App component
//          - "/details/id" -> Details pad moet leiden naar de DetailsPage, LET OP: dynamische id dus bvb. details/14
//          - "/favorites"  -> Favorites pad moet leiden naar de FavoritesPage

const browserRouter = createBrowserRouter([
  {
    path: "/", // Hoofdpagina (Root)
    element: <RootLayout />, // Root layout voor gedeelde structuur zoals navigatie
    children: [
      {
        index: true, // Standaard pagina wanneer "/" wordt geopend
        element: <App />, // Hoofdpagina (App component)
      },
      {
        path: "/details/:id", // Dynamisch pad met een ID-parameter
        element: <DetailsPage />, // Pagina voor details van een fruitsoort
      },
      {
        path: "/favorites", // Favorietenpagina
        element: <FavoritesPage />, // Pagina die de favoriete fruitsoorten toont
      },
    ],
  },
]);

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    {/* TODO: Zorg dat alle componenten toegang hebben tot de FavoritesContext met behulp van FavoritesContextProvider */}
    <FavoritesContextProvider>
      {/* RouterProvider zorgt voor de navigatie tussen routes */}
      <RouterProvider router={browserRouter}></RouterProvider>
    </FavoritesContextProvider>
  </React.StrictMode>
);
