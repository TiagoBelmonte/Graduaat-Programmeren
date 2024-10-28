import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import App from "./App.jsx";
import "./index.css";
import DarkmodeContextProvider from "./contexts/DarkmodeContext.jsx";
import Movies from "./components/Movies.jsx";

import { createBrowserRouter, RouterProvider } from "react-router-dom";
import MoviesPage from "./pages/MoviesPage.jsx";
import DetailsPage from "./pages/DetailsPage.jsx";
import Header from "./components/Header.jsx";
import Footer from "./components/Footer.jsx";
import RootLayout from "./pages/RootLayout.jsx";
import NotFoundPage from "./pages/NotFoundPage.jsx";
import FavoritesPAge from "./pages/FavoritesPAge.jsx";

// Router

// Stap 1: Nieuwe browserRouter aanmaken

const browserRouter = createBrowserRouter([
  {
    element: <RootLayout />,
    errorElement: <NotFoundPage />,
    children: [
      {
        path: "/",
        element: <MoviesPage />,
      },
      {
        path: "details",
        children: [
          {
            path: "test",
            element: <App />,
          },
          {
            path: ":id",
            element: <DetailsPage />,
          },
        ],
      },
      {
        path: "favorites",
        element: <FavoritesPAge />,
      },
    ],
  },
]);

createRoot(document.getElementById("root")).render(
  <StrictMode>
    <DarkmodeContextProvider>
      <RouterProvider router={browserRouter} />
      {/*<App />*/}
      {/*<Movies />*/}
    </DarkmodeContextProvider>
  </StrictMode>
);
