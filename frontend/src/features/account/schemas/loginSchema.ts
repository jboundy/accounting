import * as yup from "yup";
import { IAccountsLoginRequest } from "../../../api/apiClient";

export const loginSchema: yup.ObjectSchema<IAccountsLoginRequest> = yup.object({
  userName: yup.string().required("User Name is required"),
  password: yup.string().required("Password is required"),
});
