import React, { useEffect, useState } from "react";
import {
  View,
  Text,
  FlatList,
  TouchableOpacity,
  StyleSheet,
  ActivityIndicator,
} from "react-native";
import * as Location from "expo-location"; // (dia 132) Native GPS-functionaliteit via Expo Location
import WeatherCard from "../components/WeatherCard";
import { fetchWeatherByCity, fetchWeatherByCoords } from "../api/weather"; // (dia 143–144) Data ophalen via externe API
import { fetchCityListFromFirestore } from "../api/firestore"; // (dia 143) Firestore city list ophalen
import { useDispatch, useSelector } from "react-redux"; // (dia 135–136) Redux hooks
import { addFavorite, removeFavorite } from "../store/favorites/slice";
import { City } from "../navigation/types";
import MyText from "../components/MyText"; // (custom styled text component)

export default function WeatherScreen() {
  const [data, setData] = useState<any[]>([]);
  const [locationWeather, setLocationWeather] = useState<any | null>(null);
  const [loading, setLoading] = useState(true);

  const favorites: City[] = useSelector((state: any) => state.favorites ?? []); // (dia 136) Redux state uitlezen
  const dispatch = useDispatch();

  useEffect(() => {
    const load = async () => {
      try {
        const firebaseCities = await fetchCityListFromFirestore(); // (dia 143) Ophalen uit Firestore
        const weatherList = await Promise.all(
          firebaseCities.map(async (city) => {
            try {
              const res = await fetchWeatherByCity(city); // (dia 143–144)
              if (res.cod !== 200) return null;
              return {
                city,
                temp: res.main.temp,
                desc: res.weather[0].description,
              };
            } catch (err) {
              return null;
            }
          })
        );
        setData(weatherList.filter((item) => item !== null)); // filter lege resultaten
      } catch (e) {
        console.error("❌ Fout bij ophalen van steden/weer:", e);
      } finally {
        setLoading(false);
      }
    };

    load(); // (bij initial render)
  }, []);

  const getLocation = async () => {
    const { status } = await Location.requestForegroundPermissionsAsync(); // (dia 132) Locatiepermissie vragen
    if (status !== "granted") return;

    const loc = await Location.getCurrentPositionAsync({});
    const res = await fetchWeatherByCoords(
      loc.coords.latitude,
      loc.coords.longitude
    );

    setLocationWeather({
      city: res.name,
      temp: res.main.temp,
      desc: res.weather[0].description,
    });
  };

  const isFavorite = (cityName: string) =>
    favorites.some((fav) => fav.name === cityName); // check of stad in favorieten zit

  return (
    <View style={styles.container}>
      {/* (dia 132–133) Locatieknop */}
      <TouchableOpacity style={styles.locationButton} onPress={getLocation}>
        <Text style={styles.locationButtonText}>📍 Gebruik mijn locatie</Text>
      </TouchableOpacity>

      {locationWeather && (
        <View style={styles.section}>
          <MyText style={styles.sectionTitle}>Jouw locatie</MyText>
          <WeatherCard
            city={locationWeather.city}
            temp={locationWeather.temp}
            desc={locationWeather.desc}
          />
        </View>
      )}

      <MyText style={styles.sectionTitle}>Steden uit Firebase</MyText>

      {loading ? (
        <ActivityIndicator size="large" color="#3b82f6" />
      ) : (
        <FlatList
          data={data}
          keyExtractor={(item) => item.city}
          contentContainerStyle={{ paddingBottom: 40 }}
          renderItem={({ item }) => (
            <View style={styles.cardContainer}>
              <WeatherCard city={item.city} temp={item.temp} desc={item.desc} />
              <TouchableOpacity
                style={styles.favButton}
                onPress={() =>
                  isFavorite(item.city)
                    ? dispatch(removeFavorite(item.city)) // (dia 135) Redux action dispatchen
                    : dispatch(addFavorite({ name: item.city }))
                }
              >
                <MyText style={styles.favButtonText}>
                  {isFavorite(item.city)
                    ? "⭐ Verwijder favoriet"
                    : "☆ Voeg toe aan favorieten"}
                </MyText>
              </TouchableOpacity>
            </View>
          )}
        />
      )}
    </View>
  );
}
const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#f0f4f8",
    paddingHorizontal: 20,
    paddingTop: 40,
  },
  section: {
    marginBottom: 20,
  },
  sectionTitle: {
    fontSize: 20,
    fontWeight: "bold",
    color: "#1e3a8a",
    marginBottom: 10,
  },
  locationButton: {
    backgroundColor: "#3b82f6",
    paddingVertical: 14,
    borderRadius: 8,
    alignItems: "center",
    marginBottom: 20,
  },
  locationButtonText: {
    color: "#fff",
    fontSize: 16,
    fontWeight: "bold",
  },
  cardContainer: {
    marginBottom: 16,
  },
  favButton: {
    marginTop: 8,
    alignItems: "center",
  },
  favButtonText: {
    color: "#3b82f6",
    fontSize: 16,
    fontWeight: "600",
  },
});
