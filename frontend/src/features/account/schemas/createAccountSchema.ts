import * as yup from "yup";
import { IAccountsCreateAccountRequest } from "../../../api/apiClient";

export const createAccountSchema: yup.ObjectSchema<IAccountsCreateAccountRequest> =
  yup.object({
    firstName: yup.string().required("First Name is required"),
    lastName: yup.string().required("Last Name is required"),
    userName: yup.string().required("User Name is required"),
    password: yup.string().required("Password is required"),
  });
