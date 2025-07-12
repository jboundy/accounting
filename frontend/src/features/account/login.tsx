import { Button, Form } from "react-bootstrap";
import {
  AccountingApiFeaturesAccountsLoginRequest,
  IAccountsLoginRequest,
} from "../../api/apiClient";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import InputControl from "../../components/inputControl";
import { useApiClient } from "../../context/ApiClientContext";
import { loginSchema } from "./schemas/loginSchema";
import { useDispatch } from "react-redux";
import { AppDispatch } from "../../state/Store";
import { AccountState, login } from "../../state/AccountSlice";
import { useNavigate } from "react-router-dom";

export default function Login() {
  const apiClient = useApiClient();
  const dispatch = useDispatch<AppDispatch>();
  const navigate = useNavigate();
  const toRoute = `/budget/list`;
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<IAccountsLoginRequest>({
    resolver: yupResolver(loginSchema, { abortEarly: false }),
  });

  const onSubmit = async (data: IAccountsLoginRequest) => {
    const request = new AccountingApiFeaturesAccountsLoginRequest(data);
    const response = await apiClient.accountingApiFeaturesAccountsLoginEndpoint(
      request
    );
    if (response.authorized) {
      const accountPayload: AccountState = {
        userId: response.userId,
        firstName: response.firstName,
        lastName: response.lastName,
        email: response.email,
        jwtCode: response.jwtCode,
        roles: response.roles,
      };
      localStorage.setItem("jwtToken", response.jwtCode!);
      dispatch(login(accountPayload));
      navigate(toRoute);
    }
  };

  return (
    <Form onSubmit={handleSubmit(onSubmit)}>
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
      <Button variant="primary" type="submit">
        Login
      </Button>
    </Form>
  );
}
