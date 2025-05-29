import "./global.css"; // (eigen stijlingen – niet uit slides, maar oké voor consistentie)

import { NavigationContainer } from "@react-navigation/native"; // (dia 152) Navigatie rootcontainer
import { StatusBar } from "expo-status-bar";
import { StyleSheet } from "react-native";
import ParkingsTabNavigator from "./src/navigation/MainTabNavigator"; // hoofdapp via tabs
import { QueryClient, QueryClientProvider } from "@tanstack/react-query"; // (dia 148) React Query gebruiken
import { useForegroundPermissions } from "expo-location"; // (dia 132) GPS toestemming vragen
import { useEffect, useState } from "react";
import DarkModeContextProvider from "./src/contexts/DarkModeContext"; // (eigen context – logisch maar niet in slides)
import * as SplashScreen from "expo-splash-screen";
import { useFonts } from "expo-font"; // (dia 91) Custom fonts laden
import { Provider } from "react-redux";
import { persistedStore, store } from "./src/store/store"; // (dia 146–147) Redux + persist setup
import { PersistGate } from "redux-persist/integration/react";
import AuthStackNavigator from "./src/navigation/AuthStackNavigator"; // (dia 159) Auth flow
import { auth } from "./src/config/firebase";
import { onAuthStateChanged, Unsubscribe } from "firebase/auth"; // (dia 25) observer voor login status

const queryClient = new QueryClient(); // (dia 148) Query client aanmaken

SplashScreen.preventAutoHideAsync(); // splash screen pas verbergen als fonts geladen zijn

export default function App() {
  const [locationStatus, requestLocationPermission] =
    useForegroundPermissions(); // (dia 132)

  const [isLoggedIn, setIsLoggedIn] = useState(true); // loginstatus beheren

  useEffect(() => {
    requestLocationPermission(); // (dia 132–133) toestemming vragen bij opstart
  }, []);

  const [isFontLoaded, fontError] = useFonts({
    DeliusSwashCaps: require("./assets/fonts/DeliusSwashCaps-Regular.ttf"), // (dia 91) verplichte custom font
  });

  useEffect(() => {
    let unsubscribe: Unsubscribe;
    if (isFontLoaded || fontError) {
      unsubscribe = onAuthStateChanged(auth, async (user) => {
        console.log("INGELOGD: ", user);
        setIsLoggedIn(user !== null); // (dia 25) auth observer checkt loginstatus
        SplashScreen.hideAsync();
      });
    }

    return () => {
      if (unsubscribe) {
        unsubscribe(); // (netjes afmelden)
      }
    };
  }, [isFontLoaded, fontError]);

  if (!isFontLoaded && !fontError) {
    return null; // wacht op fonts
  }

  return (
    <Provider store={store}>
      {/* (dia 136) Redux store aanbieden */}
      <PersistGate persistor={persistedStore}>
        {/* (dia 147) wacht tot opslag geladen is */}
        <DarkModeContextProvider>
          {/* eigen contextprovider */}
          <QueryClientProvider client={queryClient}>
            {/* (dia 148) React Query */}
            <NavigationContainer>
              {/* (dia 152) Navigatiestructuur */}
              {isLoggedIn ? <ParkingsTabNavigator /> : <AuthStackNavigator />}
              <StatusBar style="auto" />
            </NavigationContainer>
          </QueryClientProvider>
        </DarkModeContextProvider>
      </PersistGate>
    </Provider>
  );
}
