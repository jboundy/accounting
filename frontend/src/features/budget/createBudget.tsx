import { Button, Form } from "react-bootstrap";
import {
  AccountingApiEntitiesExpense,
  IEntitiesBudget,
} from "../../api/apiClient";
import CurrencyInput from "../../components/currencyInput";
import { useForm } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";

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

const schema: yup.ObjectSchema<IEntitiesBudget> = yup.object({
  id: yup.number(),
  name: yup.string().required("Budget Name is required"),
  expectedAmountToSpend: yup.number().required(),
  expenses: yup.array().of(singleExpenseSchema),
  actualAmountSpent: yup.number(),
});

export default function CreateBudget() {
  const {
    register,
    getValues,
    setValue,
    handleSubmit,
    formState: { errors },
  } = useForm<IEntitiesBudget>({
    resolver: yupResolver(schema, { abortEarly: false }),
  });

  const onSubmit = (data: IEntitiesBudget) => {
    console.log(data);
  };

  return (
    <Form onSubmit={handleSubmit(onSubmit)}>
      <Form.Group className="mb-3" controlId="name">
        <Form.Label>Name</Form.Label>
        <Form.Control
          {...register("name")}
          type="input"
          placeholder="Enter Budget Name"
          isInvalid={!!errors.name}
        />
        <Form.Control.Feedback type="invalid">
          {errors.name?.message}
        </Form.Control.Feedback>
      </Form.Group>

      <Form.Group className="mb-3" controlId="expectedAmountToSpend">
        <CurrencyInput
          value={getValues("expectedAmountToSpend") || 0}
          onChange={function (value: number): void {
            setValue("expectedAmountToSpend", value);
          }}
        />
        <Form.Control.Feedback type="invalid">
          {errors.expectedAmountToSpend?.message}
        </Form.Control.Feedback>
      </Form.Group>
      <Button variant="primary" type="submit">
        Submit
      </Button>
    </Form>
  );
}
