import { createSlice, PayloadAction } from "@reduxjs/toolkit";
// (dia 133–134) createSlice maakt automatisch reducers en acties

type UserInfo = {
  name: string;
  age: string;
};
// (type safety – zie ook dia 169 voor typestructuur in navigatiecontext)

const initialState: UserInfo = {
  name: "",
  age: "",
};
// (initiële state – lege naam en leeftijd)

const userSlice = createSlice({
  name: "user", // (dia 134) unieke slice-naam
  initialState,
  reducers: {
    setUserInfo: (state, action: PayloadAction<UserInfo>) => {
      // (dia 134) reducer-functie met payload van type UserInfo
      state.name = action.payload.name;
      state.age = action.payload.age;
    },
  },
});

export const { setUserInfo } = userSlice.actions; // (dia 135) actie exporteren voor gebruik in componenten
export default userSlice.reducer; // (dia 135) reducer exporteren voor gebruik in de store
