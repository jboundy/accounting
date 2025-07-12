import { createSlice, PayloadAction } from "@reduxjs/toolkit";

export interface AccountState {
  userId: string | undefined;
  firstName: string | undefined;
  lastName: string | undefined;
  email: string | undefined;
  jwtCode: string | undefined;
  roles: string[] | undefined;
}

const initialState: AccountState = {
  userId: undefined,
  firstName: undefined,
  lastName: undefined,
  email: undefined,
  jwtCode: undefined,
  roles: [],
};

const accountSlice = createSlice({
  name: "account",
  initialState,
  reducers: {
    login: (state, action: PayloadAction<AccountState>) => {
      Object.assign(state, action.payload);
    },
    logout: (state) => {
      state.jwtCode = undefined;
      state.userId = undefined;
      state.email = undefined;
      state.firstName = undefined;
      state.lastName = undefined;
      state.roles = [];
    },
  },
});

export const { login, logout } = accountSlice.actions;
export default accountSlice.reducer;
