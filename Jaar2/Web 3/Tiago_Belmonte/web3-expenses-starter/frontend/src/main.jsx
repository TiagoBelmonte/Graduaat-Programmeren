import { StrictMode } from "react";
import { createRoot, RouterProvider } from "react-dom/client";
import "./index.css";
import { createBrowserRouter } from "react-router-dom";
import RootLayout from "./layouts/RootLayout.jsx";
import TransactionsPage from "./pages/TransactionsPage.jsx";
import CategoriesPage from "./pages/CategoriesPage.jsx";
import ProfilePage from "./pages/ProfilePage.jsx";
import LoginPage from "./pages/LoginPage.jsx";
import AddTransactionPage from "./pages/AddTransactionPage.jsx";
import ProtectedRoute from "./components/ProtectedRoute.jsx";
import AuthContextProvider from "./contexts/AuthContextProvider.jsx";

const browserRouter = createBrowserRouter([
  {
    element: (
      // TODO: Zorg ervoor dat de RootLayout gewrapped wordt met de ProtectedRoute component
      <ProtectedRoute>
        <RootLayout />
      </ProtectedRoute>
    ),
    children: [
      {
        path: "/",
        element: <TransactionsPage />,
      },
      {
        path: "/add",
        element: <AddTransactionPage />,
      },
      {
        path: "/categories",
        element: <CategoriesPage />,
      },
      {
        path: "/profile",
        element: <ProfilePage />,
      },
    ],
  },
  {
    path: "/login",
    element: <LoginPage />,
  },
]);

createRoot(document.getElementById("root")).render(
  <StrictMode>
    {/* TODO: Zorg ervoor dat de AuthContext gebruikt kan worden in deze app */}
    <AuthContextProvider>
      <RouterProvider router={browserRouter} />
    </AuthContextProvider>
    {/* TODO: Zorg ervoor dat de routing kan gebruikt worden in deze app */}
  </StrictMode>
);
