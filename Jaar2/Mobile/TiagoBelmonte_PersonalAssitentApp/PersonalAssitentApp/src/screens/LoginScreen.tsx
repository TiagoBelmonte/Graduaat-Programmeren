import {
  Button,
  Platform,
  StyleSheet,
  Text,
  TextInput,
  View,
  TouchableOpacity, // (dia 120) Zelfgemaakte knoppen met styling
} from "react-native";
import React from "react";
import { useFormik } from "formik"; // (dia 140) Formulierverwerking met Formik
import * as Yup from "yup"; // (dia 143) Validatieschema’s met Yup
import { signInWithEmailAndPassword } from "firebase/auth"; // (dia 25) Firebase login methode
import { auth } from "../config/firebase"; // (dia 22) Firebase configuratie importeren
import { useNavigation } from "@react-navigation/native"; // (dia 159) Navigeren via props
import MyText from "../components/MyText"; // (custom styled text component)

const validationSchema = Yup.object().shape({
  email: Yup.string()
    .email("Geen geldig e-mailadres.") // (dia 144) Yup emailvalidatie
    .required("Verplicht veld."),
  password: Yup.string().required("Verplicht veld."), // (dia 144)
});

const LoginScreen = () => {
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
      email: "",
      password: "",
    },
    onSubmit: async (values) => {
      try {
        const user = await signInWithEmailAndPassword(
          auth,
          values.email,
          values.password
        ); // (dia 25) Firebase login: signInWithEmailAndPassword
        console.log("Ingelogd als:", user.user.email);
      } catch (error) {
        console.log(error); // (eenvoudige foutafhandeling)
      }
    },
    validationSchema, // (dia 144) Koppeling Yup aan Formik
  });

  return (
    <View style={styles.container}>
      {/* (dia 115) Styling met StyleSheet object */}
      <MyText style={styles.title}>Welkom terug 👋</MyText>
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
        autoComplete={Platform.OS === "ios" ? "email" : "address-line1"}
        // (dia 139) Gebruik van TextInput met goede UX properties
      />
      {touched.email && errors.email && (
        <Text style={styles.errorText}>{errors.email}</Text> // (dia 144) Toon foutmelding bij validatiefout
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
        style={styles.loginButton}
        onPress={() => handleSubmit()} // (dia 140) handleSubmit van Formik
      >
        <MyText style={styles.loginButtonText}>Login</MyText>
      </TouchableOpacity>
      <TouchableOpacity onPress={() => navigation.navigate("Register")}>
        {/* (dia 159) Navigeren naar registratie */}
        <MyText style={styles.registerLink}>
          Nog geen account?
          <MyText style={styles.registerHighlight}>Registreer</MyText>
        </MyText>
      </TouchableOpacity>
    </View>
  );
};

export default LoginScreen;

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
  loginButton: {
    backgroundColor: "#3b82f6",
    paddingVertical: 14,
    borderRadius: 8,
    alignItems: "center",
    marginTop: 12,
  },
  loginButtonText: {
    color: "#fff",
    fontSize: 16,
    fontWeight: "bold",
  },
  registerLink: {
    marginTop: 20,
    textAlign: "center",
    color: "#475569",
  },
  registerHighlight: {
    color: "#3b82f6",
    fontWeight: "bold",
  },
});
