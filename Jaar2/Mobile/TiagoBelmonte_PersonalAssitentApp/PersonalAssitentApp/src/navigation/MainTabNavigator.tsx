import { View, Text } from "react-native";
import React from "react";
import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
// (dia 167) Bottom tab navigator importeren

import { ParkingsTabParamsList } from "./types"; // (dia 169) Type-safe navigatie via params list
import ParkingsDrawerNavigator from "./InformationDrawerNavigator"; // (dia 170) Geneste navigators combineren (tab + drawer)

import FavoritesScreen from "../screens/FavoritesScreen";
import WeatherScreen from "../screens/WeatherScreen";
import HomeScreen from "../screens/HomeScreen";
import NewsScreen from "../screens/NewsScreen";

import MaterialIcons from "@expo/vector-icons/MaterialCommunityIcons";
// (dia 168) Iconen gebruiken bij tabBarItems

const ParkingsTab = createBottomTabNavigator<ParkingsTabParamsList>();

const ParkingsTabNavigator = () => {
  return (
    <ParkingsTab.Navigator
      screenOptions={{
        headerTitleStyle: { fontFamily: "Montserrat" }, // (dia 91) custom font toepassen
        tabBarLabelStyle: { fontFamily: "Montserrat" },
      }}
    >
      <ParkingsTab.Screen
        name="Home"
        component={HomeScreen}
        options={{
          headerShown: false,
          tabBarIcon: ({ color, size }) => (
            <MaterialIcons name="home" color={color} size={size} />
          ),
        }}
      />
      <ParkingsTab.Screen
        name="Weather"
        component={WeatherScreen}
        options={{
          tabBarIcon: ({ color, size }) => (
            <MaterialIcons name="weather-cloudy" color={color} size={size} />
          ),
        }}
      />
      <ParkingsTab.Screen
        name="Favorites"
        component={FavoritesScreen}
        options={{
          tabBarIcon: ({ color, size }) => (
            <MaterialIcons name="star" color={color} size={size} />
          ),
        }}
      />
      <ParkingsTab.Screen
        name="News"
        component={NewsScreen}
        options={{
          headerShown: false,
          tabBarIcon: ({ color, size }) => (
            <MaterialIcons name="newspaper" color={color} size={size} />
          ),
        }}
      />
      <ParkingsTab.Screen
        name="Settings"
        component={ParkingsDrawerNavigator} // (dia 170) Drawer genest in tab voor extra opties
        options={{
          headerShown: false,
          tabBarIcon: ({ color, size }) => (
            <MaterialIcons name="cog" color={color} size={size} />
          ),
        }}
      />
    </ParkingsTab.Navigator>
  );
};

export default ParkingsTabNavigator;
