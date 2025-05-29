import {
  StyleSheet,
  Text,
  View,
  TextInput,
  Alert,
  TouchableOpacity, // (dia 120) Voor zelfgemaakte knoppen
} from "react-native";
import React, { useState } from "react";
import {
  getAuth,
  EmailAuthProvider,
  reauthenticateWithCredential,
  updatePassword,
} from "firebase/auth"; // (dia 28) Firebase authenticatiemethodes
import MyText from "../components/MyText"; // (custom styled text component)

const LocationScreen = () => {
  // 👈 zou beter hernoemd worden naar ResetPasswordScreen
  const [currentPassword, setCurrentPassword] = useState("");
  const [newPassword, setNewPassword] = useState("");

  const auth = getAuth();
  const user = auth.currentUser;

  const handlePasswordChange = async () => {
    if (!user || !user.email) {
      Alert.alert("Fout", "Gebruiker niet ingelogd."); // (UX feedback)
      return;
    }

    if (!currentPassword || !newPassword) {
      Alert.alert("Fout", "Vul beide wachtwoorden in.");
      return;
    }

    const credential = EmailAuthProvider.credential(
      user.email,
      currentPassword
    ); // (dia 28) Herauthenticatie vereist vóór wachtwoordwijziging

    try {
      await reauthenticateWithCredential(user, credential); // (dia 28)
      await updatePassword(user, newPassword); // (dia 28)
      Alert.alert("Succes", "Wachtwoord gewijzigd!");
      setCurrentPassword("");
      setNewPassword("");
    } catch (error: any) {
      let message = "Er is iets fout gegaan.";
      if (error.code === "auth/wrong-password")
        message = "Oud wachtwoord is verkeerd.";
      if (error.code === "auth/weak-password")
        message = "Nieuw wachtwoord is te zwak.";
      Alert.alert("Fout", message); // (goede UX voor foutmeldingen)
    }
  };

  return (
    <View style={styles.container}>
      <MyText style={styles.title}>🔒 Wijzig je wachtwoord</MyText>

      <TextInput
        placeholder="Huidig wachtwoord"
        secureTextEntry
        value={currentPassword}
        onChangeText={setCurrentPassword}
        style={styles.input}
      />
      <TextInput
        placeholder="Nieuw wachtwoord"
        secureTextEntry
        value={newPassword}
        onChangeText={setNewPassword}
        style={styles.input}
      />

      <TouchableOpacity style={styles.button} onPress={handlePasswordChange}>
        <Text style={styles.buttonText}>Wijzig wachtwoord</Text>
      </TouchableOpacity>
    </View>
  );
};

export default LocationScreen;
const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#f0f4f8",
    paddingHorizontal: 20,
    paddingTop: 40,
    gap: 16,
  },
  title: {
    fontSize: 22,
    fontWeight: "bold",
    color: "#1e3a8a",
    marginBottom: 10,
    textAlign: "center",
  },
  input: {
    backgroundColor: "#ffffff",
    padding: 12,
    borderRadius: 8,
    borderColor: "#cbd5e1",
    borderWidth: 1,
    fontSize: 16,
  },
  button: {
    backgroundColor: "#3b82f6",
    paddingVertical: 14,
    borderRadius: 8,
    alignItems: "center",
    marginTop: 10,
  },
  buttonText: {
    color: "#fff",
    fontSize: 16,
    fontWeight: "bold",
  },
});
