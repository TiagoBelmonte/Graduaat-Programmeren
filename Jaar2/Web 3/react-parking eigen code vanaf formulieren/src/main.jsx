import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import App from "./App.jsx";
import ParkingListPage from "./pages/ParkingListPage.jsx";

import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import ParkingsMapPage from "./pages/ParkingsMapPage.jsx";
import AddParkingsPage from "./pages/AddParkingsPage.jsx";
import AddParkingFormikPage from "./pages/AddParkingFormikPage.jsx";

const queryClient = new QueryClient();

createRoot(document.getElementById("root")).render(
  <StrictMode>
    <QueryClientProvider client={queryClient}>
      {/*<ParkingsMapPage /> */}
      {/*<AddParkingsPage /> */}
      <AddParkingFormikPage />
    </QueryClientProvider>
  </StrictMode>
);
