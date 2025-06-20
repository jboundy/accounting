import * as yup from "yup";
import {
  AccountingApiEntitiesExpense,
  IEntitiesBudget,
} from "../../../api/apiClient";

const singleExpenseSchema: yup.ObjectSchema<AccountingApiEntitiesExpense> =
  yup.object({
    id: yup.number().required(),
    budgetId: yup.number().optional(),
    category: yup.string().required(),
    amount: yup.number().required(),
    date: yup.date().required(),

    init: yup
      .mixed<(_data?: unknown) => void>()
      .test(
        "is-function",
        "init must be a function",
        (value): value is (_data?: unknown) => void =>
          typeof value === "function"
      )
      .required(),

    toJSON: yup
      .mixed<() => object>()
      .test(
        "is-function",
        "toJSON must be a function",
        (value): value is () => object => typeof value === "function"
      )
      .required(),
  });

export const editBudgetSchema: yup.ObjectSchema<IEntitiesBudget> = yup.object({
  id: yup.number(),
  userId: yup.number(),
  name: yup.string().required("Budget Name is required"),
  expectedAmountToSpend: yup.number().required(),
  expenses: yup.array().of(singleExpenseSchema),
  actualAmountSpent: yup.number(),
});
