import { combineReducers } from "@reduxjs/toolkit";
import accountReducer from "./AccountSlice";

const combinedReducers = combineReducers({
  account: accountReducer,
});

export default combinedReducers;
export type RootState = ReturnType<typeof combinedReducers>;
