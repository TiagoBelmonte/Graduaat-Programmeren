import { TypedUseSelectorHook, useDispatch, useSelector } from "react-redux";
// (dia 135–136) Gebruik van useDispatch en useSelector hooks voor toegang tot de store

import { AppDispatch, RootState } from "../store/store";
// (dia 131) RootState en AppDispatch worden gedefinieerd in store.ts voor type safety

export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;
// (dia 136) Typed selector gebruiken om types van de state automatisch te herkennen

export const useAppDispatch = () => useDispatch<AppDispatch>();
// (dia 136) Typed dispatch zodat je enkel correcte actions kunt dispatchen
