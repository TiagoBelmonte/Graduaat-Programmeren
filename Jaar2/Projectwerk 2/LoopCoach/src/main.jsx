import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import DarkmodeContextProvider from "./contexts/DarkmodeContext.jsx";

import { createBrowserRouter, RouterProvider } from "react-router-dom";
import Header from "./components/Header.jsx";
import Footer from "./components/Footer.jsx";
import RootLayout from "./pages/RootLayout.jsx";
import NotFoundPage from "./pages/NotFoundPage.jsx";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import Home from "./pages/Home.jsx";
import LogInPage from "./pages/LogInPage.jsx";
import ProfilePage from "./pages/ProfilePage.jsx";
import TrainingPage from "./pages/TrainingPage.jsx";
import VoedingPage from "./pages/VoedingPage.jsx";
import HomeTrainer from "./pages/HomeTrainer.jsx";
import NewTrainingPage from "./pages/NewTrainingPage.jsx";
import HomeGebruikerViaTrainer from "./pages/HomeGebruikerViaTrainer.jsx";
import NewVoedingPage from "./pages/NewVoedingPage.jsx";

// Router

// Stap 1: Nieuwe browserRouter aanmaken

const browserRouter = createBrowserRouter([
  {
    element: <RootLayout />,
    errorElement: <NotFoundPage />,
    children: [
      {
        path: "homegebruiker",
        element: <Home />,
      },
      {
        path: "hometrainer",
        element: <HomeTrainer />,
      },
      {
        path: "homegebruikertrainer",
        element: <HomeGebruikerViaTrainer />,
      },
      {
        path: "/",
        element: <LogInPage />,
      },
      {
        path: "Profile",
        element: <ProfilePage />,
      },
      {
        path: "Training",
        element: <TrainingPage />,
      },
      {
        path: "NewTraining",
        element: <NewTrainingPage />,
      },
      {
        path: "Dieet",
        element: <VoedingPage />,
      },
      {
        path: "NieuwDieet",
        element: <NewVoedingPage />,
      },
      {
        path: "nieuwTraining",
        element: <NewTrainingPage />,
      },
    ],
  },
]);

const queryClient = new QueryClient();

createRoot(document.getElementById("root")).render(
  <StrictMode>
    <QueryClientProvider client={queryClient}>
      <DarkmodeContextProvider>
        <RouterProvider router={browserRouter} />
      </DarkmodeContextProvider>
    </QueryClientProvider>
  </StrictMode>
);
