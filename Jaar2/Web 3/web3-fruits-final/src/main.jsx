import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.jsx";
import "./index.css";
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import RootLayout from "./navigation/RootLayout.jsx";
import DetailsPage from "./pages/DetailsPage.jsx";
import FavoritesContextProvider from "./contexts/FavoritesContextProvider.jsx";
import FavoritesPage from "./pages/FavoritesPage.jsx";

const browserRouter = createBrowserRouter([
  {
    path: "/",
    element: <RootLayout />,
    children: [
      {
        index: true,
        element: <App />,
      },
      {
        path: "/details/:id",
        element: <DetailsPage />,
      },
      // TODO: Implementeer favorieten pagina
      {
        path: "/favorites",
        element: <FavoritesPage />,
      },
    ],
  },
]);

ReactDOM.createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <FavoritesContextProvider>
      <RouterProvider router={browserRouter}></RouterProvider>
    </FavoritesContextProvider>
  </React.StrictMode>
);
