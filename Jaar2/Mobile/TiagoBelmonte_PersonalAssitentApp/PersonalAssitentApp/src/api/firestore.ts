import { doc, getDoc } from "firebase/firestore"; // (dia 21–22) Firebase Web SDK + Firestore
import { db } from "../config/firebase"; // (dia 22) Initialisatieproject + export db vanuit Firebase config

export async function fetchCityListFromFirestore(): Promise<string[]> {
  try {
    const docRef = doc(db, "Cities", "28VUfhnH2g0ueZZvdYZX"); // (dia 21) Voorbeeld Firestore document ophalen
    const docSnap = await getDoc(docRef); // (dia 21) getDoc gebruikt voor éénmalige fetch

    if (docSnap.exists()) {
      const data = docSnap.data();

      if (!data.cities || !Array.isArray(data.cities)) {
        console.error("❌ Veld 'cities' is niet correct opgebouwd.");
        return [];
      }

      const citiesMap = data.cities[0];
      const cityNames = Object.keys(citiesMap);

      return cityNames;
    } else {
      console.error("❌ Firestore document niet gevonden.");
      return [];
    }
  } catch (err) {
    console.error("❌ Fout bij ophalen Firestore:", err);
    return [];
  }
}

//Deze functie haalt uit Firestore een document op met een lijst van steden in een veld cities,
//haalt daaruit de namen van de steden, en stuurt deze terug als een array van strings.
