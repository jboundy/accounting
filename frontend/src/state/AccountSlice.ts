import { createSlice, PayloadAction } from "@reduxjs/toolkit";

export interface AccountState {
  userId: string | null;
  firstName: string | null;
  lastName: string | null;
  email: string | null;
  token: string | null;
  roles: string[];
}

const initialState: AccountState = {
  userId: null,
  firstName: null,
  lastName: null,
  email: null,
  token: null,
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
      state.token = null;
      state.userId = null;
      state.email = null;
      state.firstName = null;
      state.lastName = null;
      state.roles = [];
    },
  },
});

export const { login, logout } = accountSlice.actions;
export default accountSlice.reducer;
