import { Form } from "react-bootstrap";
import {
  AccountingApiFeaturesBudgetsUpdateBudgetRequest,
  EntitiesBudget,
  IEntitiesBudget,
} from "../../api/apiClient";
import CurrencyInput from "../../components/currencyInput";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import SubmitButton from "../../components/submitButton";
import InputControl from "../../components/inputControl";
import { useApiClient } from "../../context/ApiClientContext";
import { editBudgetSchema } from "./schemas/editBudgetSchema";

interface EditBudgetProps {
  budget: IEntitiesBudget;
}

export default function EditBudget({ budget }: EditBudgetProps) {
  const apiClient = useApiClient();
  const {
    register,
    getValues,
    setValue,
    handleSubmit,
    formState: { errors },
  } = useForm<IEntitiesBudget>({
    defaultValues: budget,
    resolver: yupResolver(editBudgetSchema, { abortEarly: false }),
  });

  const onSubmit = async (data: IEntitiesBudget) => {
    const request = new AccountingApiFeaturesBudgetsUpdateBudgetRequest();
    request.budget = new EntitiesBudget(data);

    const response =
      await apiClient.accountingApiFeaturesBudgetsUpdateBudgetEndpoint(request);

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
