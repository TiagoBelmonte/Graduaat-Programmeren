import AsyncStorage from "@react-native-async-storage/async-storage"; // (dia 137) AsyncStorage gebruiken als alternatief voor localStorage op mobiel
import { initializeApp } from "firebase/app"; // (dia 22) Initialiseer Firebase App met config
import {
  initializeAuth,
  getReactNativePersistence,
  getAuth,
} from "firebase/auth"; // (dia 23) Firebase Auth importeren
import { getFirestore } from "firebase/firestore"; // (dia 21) Firestore gebruiken als database

const firebaseConfig = {
  apiKey: "AIzaSyBAIPxcSgBXexLvcOo2FJSm1CPocCTGDhc", // (dia 22) Config uit Firebase dashboard halen
  authDomain: "mobile-personal-assistent.firebaseapp.com",
  projectId: "mobile-personal-assistent",
  storageBucket: "mobile-personal-assistent.appspot.com",
  messagingSenderId: "613733732607",
  appId: "1:613733732607:web:b67858cb91541c5627fcca",
  measurementId: "G-BPX5F6RKEN",
};

export const app = initializeApp(firebaseConfig); // (dia 22) Firebase initialisatie

initializeAuth(app, {
  persistence: getReactNativePersistence(AsyncStorage),
  // (dia 25 + 137) Zorgt ervoor dat gebruikerssessie wordt bewaard via AsyncStorage
});

export const auth = getAuth(app); // (dia 23) Auth object exporteren voor login/register
export const db = getFirestore(app); // (dia 21) Firestore exporteren om databankacties uit te voeren
