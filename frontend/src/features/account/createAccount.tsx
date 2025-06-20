import { Form } from "react-bootstrap";
import {
  AccountsCreateAccountRequest,
  IAccountsCreateAccountRequest,
} from "../../api/apiClient";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import SubmitButton from "../../components/submitButton";
import InputControl from "../../components/inputControl";
import { useApiClient } from "../../context/ApiClientContext";
import { createAccountSchema } from "./schemas/createAccountSchema";

export default function CreateAccount() {
  const apiClient = useApiClient();
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<IAccountsCreateAccountRequest>({
    resolver: yupResolver(createAccountSchema, { abortEarly: false }),
  });

  const onSubmit = async (data: IAccountsCreateAccountRequest) => {
    const request = new AccountsCreateAccountRequest(data);
    const response =
      await apiClient.accountingApiFeaturesAccountsCreateAccountEndpoint(
        request
      );

    if (response.saved) {
      alert("Account created");
    } else {
      alert("Unable to create account");
    }
  };

  return (
    <Form onSubmit={handleSubmit(onSubmit)}>
      <Form.Group className="mb-3" controlId="firstName">
        <InputControl
          register={register}
          name="firstName"
          placeholder="First Name"
          isInvalid={!!errors.firstName}
          errorMessage={errors?.firstName?.message}
        />
      </Form.Group>

      <Form.Group className="mb-3" controlId="lastName">
        <InputControl
          register={register}
          name="lastName"
          placeholder="Last Name"
          isInvalid={!!errors.lastName}
          errorMessage={errors?.lastName?.message}
        />
      </Form.Group>

      <Form.Group className="mb-3" controlId="userName">
        <InputControl
          register={register}
          name="userName"
          placeholder="User Name"
          isInvalid={!!errors.userName}
          errorMessage={errors?.userName?.message}
        />
      </Form.Group>

      <Form.Group className="mb-3" controlId="password">
        <InputControl
          register={register}
          name="password"
          type="password"
          placeholder="Password"
          isInvalid={!!errors.password}
          errorMessage={errors?.password?.message}
        />
      </Form.Group>
      <SubmitButton />
    </Form>
  );
}
