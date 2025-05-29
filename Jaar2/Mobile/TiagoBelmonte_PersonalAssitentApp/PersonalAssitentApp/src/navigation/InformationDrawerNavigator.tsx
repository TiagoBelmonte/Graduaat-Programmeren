import React from "react";
import { createDrawerNavigator } from "@react-navigation/drawer";
// (dia 161) Drawer Navigator importeren uit React Navigation

import { ParkingsDrawerParamsList } from "./types";
// (dia 169) Gebruik maken van een type-safe navigator via TypeScript

import NativeScreen from "../screens/UserInfoScreen";
// (logische component die vermoedelijk gebruikersinfo toont)
import LocationScreen from "../screens/ResetPasswordScreen";
// (component voor wachtwoord reset – handig in settings drawer)

const ParkingsDrawer = createDrawerNavigator<ParkingsDrawerParamsList>();
// (dia 162) Drawer Navigator aanmaken en typeren

const ParkingsDrawerNavigator = () => {
  return (
    <ParkingsDrawer.Navigator>
      {/* (dia 163–165) Toevoegen van drawer screens */}
      <ParkingsDrawer.Screen name="Info" component={NativeScreen} />
      <ParkingsDrawer.Screen name="ResetPassword" component={LocationScreen} />
    </ParkingsDrawer.Navigator>
  );
};

export default ParkingsDrawerNavigator;
