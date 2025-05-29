import React, { useEffect, useState } from "react";
import {
  View,
  FlatList,
  StyleSheet,
  ActivityIndicator,
  Text,
} from "react-native";
import { useAppSelector } from "../hooks/redux"; // (dia 136) useSelector hook gebruiken om Redux state op te halen
import WeatherCard from "../components/WeatherCard"; // (eigen herbruikbaar component)
import MyText from "../components/MyText"; // (custom styled text component)
import { fetchWeatherByCity } from "../api/weather"; // (dia 143–148) API-call uitvoeren met fetch()

const FavoritesScreen = () => {
  const favorites = useAppSelector((state) => state.favorites); // (dia 136) ophalen van Redux state
  const [weatherData, setWeatherData] = useState<any[]>([]);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const load = async () => {
      setLoading(true);
      const list = await Promise.all(
        favorites.map(async (fav) => {
          try {
            const res = await fetchWeatherByCity(fav.name); // (dia 143–144) fetch-call met param
            if (res.cod !== 200) return null;

            return {
              city: fav.name,
              temp: res.main.temp,
              desc: res.weather[0].description,
            };
          } catch (err) {
            return null; // (basic foutafhandeling)
          }
        })
      );
      setWeatherData(list.filter((item) => item !== null)); // nulls filteren
      setLoading(false);
    };

    load(); // wordt uitgevoerd als favorieten wijzigen
  }, [favorites]);

  return (
    <View style={styles.container}>
      {/* (dia 109) View als container met styling */}
      <MyText style={styles.title}>⭐ Mijn Favorieten</MyText>
      {favorites.length === 0 ? (
        <MyText style={styles.emptyText}>
          Je hebt nog geen favorieten toegevoegd.
          {/* (dia 110 + 91) custom font en styled text */}
        </MyText>
      ) : loading ? (
        <ActivityIndicator size="large" color="#3b82f6" /> // (UX feedback – niet expliciet in slides)
      ) : (
        <FlatList
          data={weatherData}
          keyExtractor={(item) => item.city}
          contentContainerStyle={{ paddingBottom: 40 }}
          renderItem={({ item }) => (
            <View style={styles.item}>
              <WeatherCard city={item.city} temp={item.temp} desc={item.desc} />
            </View>
          )}
        />
      )}
    </View>
  );
};

export default FavoritesScreen;

const styles = StyleSheet.create({
  // (dia 115) Styling via StyleSheet object
  container: {
    flex: 1,
    backgroundColor: "#f0f4f8",
    paddingHorizontal: 20,
    paddingTop: 30,
  },
  title: {
    fontSize: 22,
    fontWeight: "bold",
    color: "#1e3a8a",
    marginBottom: 16,
    textAlign: "center",
  },
  emptyText: {
    fontSize: 16,
    textAlign: "center",
    marginTop: 50,
    color: "#475569",
  },
  item: {
    marginBottom: 16,
  },
});
