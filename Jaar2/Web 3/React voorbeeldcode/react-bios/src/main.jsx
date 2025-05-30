import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import App from "./App.jsx";
import "./index.css";
import DarkModeContextProvider from "./contexts/DarkModeContext.jsx";
import Movies from "./components/Movies.jsx";

import { QueryClient, QueryClientProvider } from "@tanstack/react-query";

import {
  createBrowserRouter,
  Route,
  RouterProvider,
  Routes,
} from "react-router-dom";
import MoviesPage from "./pages/MoviesPage.jsx";
import DetailsPage from "./pages/DetailsPage.jsx";
import Header from "./components/Header.jsx";
import Footer from "./components/Footer.jsx";
import RootLayout from "./pages/RootLayout.jsx";
import NotFoundPage from "./pages/NotFoundPage.jsx";
import FavoritesPage from "./pages/FavoritesPage.jsx";
import FavoritesContextProvider from "./contexts/FavoritesContext.jsx";
import StarWarsPage from "./pages/StarWarsPage.jsx";

// ROUTER

// STAP 1: Nieuwe browserRouter aanmaken

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
        // Lokale foutpagina -> enkel voor het details pagina
        errorElement: <NotFoundPage />,
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
        element: <FavoritesPage />,
      },
      {
        path: "starwars",
        element: <StarWarsPage />,
      },
    ],
  },
]);

// Oude manier ->

{
  /* <Routes>
  <Route element={<App />} path="/" />

</Routes> */
}

const queryClient = new QueryClient();

createRoot(document.getElementById("root")).render(
  <StrictMode>
    <QueryClientProvider client={queryClient}>
      <DarkModeContextProvider>
        {/* <Header /> */}
        <FavoritesContextProvider>
          <RouterProvider router={browserRouter} />
          {/* <App /> */}
          {/* <Movies /> */}
          {/* <Footer /> */}
        </FavoritesContextProvider>
      </DarkModeContextProvider>
    </QueryClientProvider>
  </StrictMode>
);
