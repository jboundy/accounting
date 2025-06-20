import { Form } from "react-bootstrap";
import { FieldValues, Path, UseFormRegister } from "react-hook-form";

interface InputControlProps<T extends FieldValues> {
  register: UseFormRegister<T>;
  name: Path<T>;
  type?: string;
  placeholder?: string;
  isInvalid?: boolean;
  errorMessage?: string | undefined;
}

const InputControl = <T extends FieldValues>({
  register,
  name,
  type,
  placeholder,
  isInvalid,
  errorMessage,
}: InputControlProps<T>) => {
  return (
    <>
      <Form.Label>{name}</Form.Label>
      <Form.Control
        {...register(name)}
        type={type ?? "text"}
        placeholder={placeholder}
        isInvalid={isInvalid}
      />
      {isInvalid && (
        <Form.Control.Feedback type="invalid">
          {errorMessage}
        </Form.Control.Feedback>
      )}
    </>
  );
};

export default InputControl;
