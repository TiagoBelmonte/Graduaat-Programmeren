import { BottomTabScreenProps } from "@react-navigation/bottom-tabs";
import { DrawerScreenProps } from "@react-navigation/drawer";
import { StackScreenProps } from "@react-navigation/stack";
// (dia 169–170) Types uit React Navigation gebruiken om schermen type-safe te maken

// Stack navigator voor Home en Details (met URL-param)
export type ParkingsStackParamsList = {
  Home: undefined;
  Details: { url: string }; // (dia 170) parameters doorgeven via route.params
};

// Stack navigator voor authenticatie
export type AuthStackParamsList = {
  Login: undefined;
  Register: undefined;
};

// Tab navigator: alle hoofdfuncties van de app
export type ParkingsTabParamsList = {
  Home: undefined;
  Weather: undefined;
  Settings: undefined;
  Favorites: undefined;
  News: undefined;
};

// Drawer navigator: extra gebruikersopties
export type ParkingsDrawerParamsList = {
  Info: undefined;
  ResetPassword: undefined;
};

// Eigen datatype voor steden (wordt gebruikt in Redux)
export type City = {
  name: string;
};

// Props helpers voor elk navigatietype (TypeScript shortcuts)
export type ParkingsStackNavProps<T extends keyof ParkingsStackParamsList> =
  StackScreenProps<ParkingsStackParamsList, T>;

export type AuthStackNavProps<T extends keyof AuthStackParamsList> =
  StackScreenProps<AuthStackParamsList, T>;

export type ParkingsTabNavProps<T extends keyof ParkingsTabParamsList> =
  BottomTabScreenProps<ParkingsTabParamsList, T>;

export type ParkingsDrawerNavProps<T extends keyof ParkingsDrawerParamsList> =
  DrawerScreenProps<ParkingsDrawerParamsList, T>;

// (dia 169) RootParamList uitbreiden zodat navigatie ook global types herkent
declare global {
  namespace ReactNavigation {
    interface RootParamList
      extends ParkingsStackParamsList,
        AuthStackParamsList,
        ParkingsTabParamsList,
        ParkingsDrawerParamsList {}
  }
}
