import { View, Text } from "react-native";
import React from "react";
import { createStackNavigator } from "@react-navigation/stack"; // (dia 159) Stack Navigator importeren

import LoginScreen from "../screens/LoginScreen";
import RegisterScreen from "../screens/RegisterScreen";
import { AuthStackParamsList } from "./types"; // (dia 169) Gebruik van type-safe navigatie via typescript params

const AuthStack = createStackNavigator<AuthStackParamsList>();

const AuthStackNavigator = () => {
  return (
    <AuthStack.Navigator
      screenOptions={{
        headerShown: false, // (UI-keuze – geen header tonen, vaak gebruikt voor auth flows)
      }}
    >
      <AuthStack.Screen name="Login" component={LoginScreen} />
      {/* (dia 157–158) Stack screen definities */}
      <AuthStack.Screen name="Register" component={RegisterScreen} />
    </AuthStack.Navigator>
  );
};

export default AuthStackNavigator;
