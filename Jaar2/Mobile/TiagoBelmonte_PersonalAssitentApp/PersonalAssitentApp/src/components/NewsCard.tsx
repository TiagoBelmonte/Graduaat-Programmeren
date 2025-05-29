import React from "react";
import {
  View,
  Text,
  StyleSheet,
  Linking,
  TouchableOpacity, // (dia 120) Zelfgemaakte buttons met TouchableOpacity
} from "react-native";

type NewsCardProps = {
  title: string;
  description: string;
  url: string;
};

const NewsCard = ({ title, description, url }: NewsCardProps) => {
  const handlePress = () => {
    Linking.openURL(url); // (dia 126) Linking opent externe link in browser
  };

  return (
    <View style={styles.card}>
      {/* (dia 109) View als container component */}
      <Text style={styles.title}>{title}</Text>
      {/* (dia 110) Text component gebruiken voor tekst */}
      <Text numberOfLines={3} style={styles.description}>
        {description}
      </Text>
      <TouchableOpacity onPress={handlePress} style={styles.button}>
        <Text style={styles.buttonText}>Lees meer →</Text>
      </TouchableOpacity>
    </View>
  );
};

export default NewsCard;

const styles = StyleSheet.create({
  // (dia 115) Gebruik van StyleSheet object voor styling
  card: {
    backgroundColor: "#e0f2fe", // (dia 124) styling via camelCase keys
    padding: 16,
    marginVertical: 10,
    borderRadius: 12,
    shadowColor: "#000", // (visueel design - niet expliciet in slides, maar goede UX)
    shadowOpacity: 0.1,
    shadowRadius: 6,
    shadowOffset: { width: 0, height: 2 },
    elevation: 3, // (Android specifieke shadow)
  },
  title: {
    fontSize: 18,
    fontWeight: "bold",
    color: "#1e3a8a",
    marginBottom: 6,
  },
  description: {
    fontSize: 15,
    color: "#334155",
    marginBottom: 12,
  },
  button: {
    alignSelf: "flex-start",
    backgroundColor: "#3b82f6",
    paddingHorizontal: 14,
    paddingVertical: 8,
    borderRadius: 8,
  },
  buttonText: {
    color: "#fff",
    fontWeight: "bold",
    fontSize: 14,
  },
});
