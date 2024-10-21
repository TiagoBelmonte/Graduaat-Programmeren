import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import App from "./App.jsx";
import "./index.css";
import DarkmodeContextProvider from "./contexts/DarkmodeContext.jsx";
import Movies from "./components/Movies.jsx";

createRoot(document.getElementById("root")).render(
  <StrictMode>
    <DarkmodeContextProvider>
      {/*<App />*/ 0}
      <Movies />
    </DarkmodeContextProvider>
  </StrictMode>
);
