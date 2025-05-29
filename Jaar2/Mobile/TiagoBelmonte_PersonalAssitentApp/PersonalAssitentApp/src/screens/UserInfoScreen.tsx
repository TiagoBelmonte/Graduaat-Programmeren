import {
  Button,
  StyleSheet,
  Text,
  TextInput,
  View,
  Alert,
  TouchableOpacity, // (dia 120) Voor custom knoppen
} from "react-native";
import React, { useState } from "react";
import { signOut } from "firebase/auth"; // (dia 28) Firebase logout methode
import { auth } from "../config/firebase";

import { useDispatch, useSelector } from "react-redux"; // (dia 135–136) Redux hooks
import { RootState } from "../store/store";
import { setUserInfo } from "../store/userInfo/userSlice"; // (dia 134–135) Redux action dispatchen
import MyText from "../components/MyText"; // (custom styled text component)

const NativeScreen = () => {
  const dispatch = useDispatch();
  const { name, age } = useSelector((state: RootState) => state.user); // (dia 136) Redux state ophalen

  const [inputName, setInputName] = useState(name);
  const [inputAge, setInputAge] = useState(age);

  const handleSave = () => {
    if (!inputName || !inputAge) {
      Alert.alert("Fout", "Vul beide velden in.");
      return;
    }

    dispatch(setUserInfo({ name: inputName, age: inputAge })); // (dia 134) Dispatch Redux action
    Alert.alert("Opgeslagen", "Je gegevens zijn bewaard.");
  };

  return (
    <View style={styles.container}>
      {/* (dia 115) Styling via StyleSheet */}
      <MyText style={styles.title}>👤 Persoonlijke Info</MyText>
      <TextInput
        style={styles.input}
        placeholder="Naam"
        value={inputName}
        onChangeText={setInputName}
      />
      <TextInput
        style={styles.input}
        placeholder="Leeftijd"
        keyboardType="numeric"
        value={inputAge}
        onChangeText={setInputAge}
      />
      <TouchableOpacity style={styles.saveButton} onPress={handleSave}>
        <Text style={styles.saveButtonText}>Opslaan</Text>
      </TouchableOpacity>
      <TouchableOpacity
        style={styles.logoutButton}
        onPress={() => signOut(auth)} // (dia 28) Uitloggen met Firebase
      >
        <Text style={styles.logoutButtonText}>Loguit</Text>
      </TouchableOpacity>
    </View>
  );
};

export default NativeScreen;
const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#f0f4f8",
    paddingHorizontal: 20,
    paddingTop: 40,
    gap: 20,
  },
  title: {
    fontSize: 22,
    fontWeight: "bold",
    color: "#1e3a8a",
    marginBottom: 12,
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
  saveButton: {
    backgroundColor: "#3b82f6",
    paddingVertical: 14,
    borderRadius: 8,
    alignItems: "center",
  },
  saveButtonText: {
    color: "#fff",
    fontSize: 16,
    fontWeight: "bold",
  },
  logoutButton: {
    backgroundColor: "#ef4444",
    paddingVertical: 14,
    borderRadius: 8,
    alignItems: "center",
  },
  logoutButtonText: {
    color: "#fff",
    fontSize: 16,
    fontWeight: "bold",
  },
});
