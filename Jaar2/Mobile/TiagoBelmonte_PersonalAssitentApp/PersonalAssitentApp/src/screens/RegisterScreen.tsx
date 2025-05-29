import {
  Platform,
  StyleSheet,
  Text,
  TextInput,
  View,
  TouchableOpacity,
  Alert, // (UX) Feedback aan gebruiker
} from "react-native";
import React from "react";
import { useFormik } from "formik"; // (dia 140) Formulieren beheren met Formik
import * as Yup from "yup"; // (dia 143) Validatie met Yup
import { createUserWithEmailAndPassword, updateProfile } from "firebase/auth"; // (dia 26–27) Firebase registratie + profiel bijwerken
import { auth } from "../config/firebase";
import { useNavigation } from "@react-navigation/native"; // (dia 159) Navigeren via props
import MyText from "../components/MyText"; // (custom styled text component)

const validationSchema = Yup.object().shape({
  name: Yup.string().required("Naam is verplicht."), // (dia 144) Yup string validatie
  email: Yup.string()
    .email("Geen geldig e-mailadres.")
    .required("Email is verplicht."),
  password: Yup.string()
    .min(6, "Minimaal 6 karakters.") // (goede UX-validatie)
    .required("Wachtwoord is verplicht."),
});

const RegisterScreen = () => {
  const navigation = useNavigation();

  const {
    values,
    errors,
    touched,
    handleChange,
    handleBlur,
    handleSubmit,
    setFieldValue,
  } = useFormik({
    initialValues: {
      name: "",
      email: "",
      password: "",
    },
    onSubmit: async (values) => {
      try {
        const userCredential = await createUserWithEmailAndPassword(
          auth,
          values.email,
          values.password
        ); // (dia 26) Firebase account aanmaken

        await updateProfile(userCredential.user, {
          displayName: values.name,
        }); // (dia 27) Gebruikersnaam instellen in Firebase

        Alert.alert("Registratie geslaagd", "Je account is aangemaakt.");
        navigation.goBack(); // (dia 159) Terug naar login scherm
      } catch (error: any) {
        Alert.alert("Fout bij registreren", error.message);
      }
    },
    validationSchema,
  });

  return (
    <View style={styles.container}>
      <MyText style={styles.title}>Account aanmaken</MyText>

      {/* (dia 139) Gebruik van TextInput met UX-optimalisaties */}
      <TextInput
        style={styles.input}
        placeholder="Naam"
        value={values.name}
        onChangeText={handleChange("name")}
        onBlur={handleBlur("name")}
        autoCapitalize="words"
        returnKeyType="next"
        autoComplete={Platform.OS === "ios" ? "name" : "name"}
      />
      {touched.name && errors.name && (
        <Text style={styles.errorText}>{errors.name}</Text>
      )}

      <TextInput
        style={styles.input}
        placeholder="Email"
        value={values.email}
        onChangeText={handleChange("email")}
        onBlur={handleBlur("email")}
        keyboardType="email-address"
        autoCapitalize="none"
        autoCorrect={false}
        returnKeyType="next"
        autoComplete={Platform.OS === "ios" ? "email" : "email"}
      />
      {touched.email && errors.email && (
        <Text style={styles.errorText}>{errors.email}</Text>
      )}

      <TextInput
        style={styles.input}
        placeholder="Wachtwoord"
        secureTextEntry
        value={values.password}
        onChangeText={handleChange("password")}
        onBlur={handleBlur("password")}
        autoComplete="password"
      />
      {touched.password && errors.password && (
        <Text style={styles.errorText}>{errors.password}</Text>
      )}

      <TouchableOpacity
        style={styles.registerButton}
        onPress={() => handleSubmit()} // (dia 140) Formik submit
      >
        <MyText style={styles.registerButtonText}>Registreren</MyText>
      </TouchableOpacity>

      <TouchableOpacity onPress={() => navigation.goBack()}>
        <MyText style={styles.loginLink}>
          Al een account? <MyText style={styles.loginHighlight}>Log in</MyText>
        </MyText>
      </TouchableOpacity>
    </View>
  );
};

export default RegisterScreen;
const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#f0f4f8",
    paddingHorizontal: 24,
    justifyContent: "center",
    gap: 14,
  },
  title: {
    fontSize: 28,
    fontWeight: "bold",
    marginBottom: 24,
    textAlign: "center",
    color: "#1e3a8a",
  },
  input: {
    backgroundColor: "#ffffff",
    padding: 12,
    borderRadius: 8,
    borderColor: "#cbd5e1",
    borderWidth: 1,
    fontSize: 16,
  },
  errorText: {
    color: "#dc2626",
    fontSize: 14,
    marginBottom: 6,
    marginTop: -6,
  },
  registerButton: {
    backgroundColor: "#3b82f6",
    paddingVertical: 14,
    borderRadius: 8,
    alignItems: "center",
    marginTop: 12,
  },
  registerButtonText: {
    color: "#fff",
    fontSize: 16,
    fontWeight: "bold",
  },
  loginLink: {
    marginTop: 20,
    textAlign: "center",
    color: "#475569",
  },
  loginHighlight: {
    color: "#3b82f6",
    fontWeight: "bold",
  },
});
