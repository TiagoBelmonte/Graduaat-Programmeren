import React from "react";
import { View, Text, StyleSheet } from "react-native"; // (dia 108–110) View en Text zijn basiscomponenten

export default function WeatherCard({
  city,
  temp,
  desc,
}: {
  city: string;
  temp: number;
  desc: string;
}) {
  return (
    <View style={styles.card}>
      {/* (dia 109) Containercomponent View met styling */}
      <Text style={styles.city}>{city}</Text>
      {/* (dia 110) Tekst moet altijd in een Text component */}
      <Text style={styles.info}>
        {desc.charAt(0).toUpperCase() + desc.slice(1)} - {temp}°C
        {/* (JS string formatting – niet in slides, maar correct gebruik) */}
      </Text>
    </View>
  );
}

const styles = StyleSheet.create({
  // (dia 115) Styling met StyleSheet object
  card: {
    backgroundColor: "#e0f2fe", // (dia 123–124) Styling met camelCase syntax
    padding: 16,
    borderRadius: 12,
    marginVertical: 8,
    shadowColor: "#000", // (UI/UX best practice – niet expliciet in slides, maar visueel relevant)
    shadowOpacity: 0.1,
    shadowRadius: 6,
    shadowOffset: { width: 0, height: 2 },
    elevation: 3, // (voor Android – schaduw, dia 124 visueel gerelateerd)
  },
  city: {
    fontSize: 20,
    fontWeight: "bold",
    color: "#1e3a8a",
    marginBottom: 4,
  },
  info: {
    fontSize: 16,
    color: "#334155",
  },
});
