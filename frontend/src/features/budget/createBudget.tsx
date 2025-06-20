import { Form } from "react-bootstrap";
import {
  AccountingApiFeaturesBudgetsCreateBudgetRequest,
  EntitiesBudget,
  IEntitiesBudget,
} from "../../api/apiClient";
import CurrencyInput from "../../components/currencyInput";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import SubmitButton from "../../components/submitButton";
import InputControl from "../../components/inputControl";
import { createBudgetSchema } from "../../schemas/createBudgetSchema";
import { useApiClient } from "../../context/ApiClientContext";

export default function CreateBudget() {
  const apiClient = useApiClient();
  const {
    register,
    getValues,
    setValue,
    handleSubmit,
    formState: { errors },
  } = useForm<IEntitiesBudget>({
    resolver: yupResolver(createBudgetSchema, { abortEarly: false }),
  });

  const onSubmit = async (data: IEntitiesBudget) => {
    const request = new AccountingApiFeaturesBudgetsCreateBudgetRequest();
    request.budget = new EntitiesBudget(data);

    const response =
      await apiClient.accountingApiFeaturesBudgetsCreateBudgetEndpoint(request);

    if (response.saved) {
      alert("Saved budget");
    } else {
      alert("Unable to save");
    }
  };

  return (
    <Form onSubmit={handleSubmit(onSubmit)}>
      <Form.Group className="mb-3" controlId="name">
        <InputControl
          register={register}
          name="name"
          placeholder="Enter Budget Name"
          isInvalid={!!errors.name}
          errorMessage={errors?.name?.message}
        />
      </Form.Group>

      <Form.Group className="mb-3" controlId="expectedAmountToSpend">
        <CurrencyInput
          value={getValues("expectedAmountToSpend") || 0}
          onChange={(value: number) => {
            setValue("expectedAmountToSpend", value);
          }}
          errorMessage={errors.expectedAmountToSpend?.message}
        />
      </Form.Group>
      <SubmitButton />
    </Form>
  );
}
