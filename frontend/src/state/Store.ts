import { configureStore } from "@reduxjs/toolkit";
import accountReducer from "../state/AccountSlice";

export const store = configureStore({
  reducer: {
    account: accountReducer,
  },
});

// Infer the `RootState` and `AppDispatch` types
export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
