import React, { useState } from "react";
import { Form } from "react-bootstrap";

interface CurrencyInputProps {
  label?: string;
  value: number;
  onChange: (value: number) => void;
  placeholder?: string;
  errorMessage?: string | undefined;
}

const CurrencyInput: React.FC<CurrencyInputProps> = ({
  label,
  value,
  onChange,
  placeholder,
  errorMessage,
}) => {
  const [display, setDisplay] = useState(formatCurrency(value));

  function formatCurrency(val: number) {
    return val.toLocaleString("en-US", {
      style: "currency",
      currency: "USD",
      minimumFractionDigits: 2,
    });
  }

  function parseCurrency(input: string): number {
    const numeric = input.replace(/[^0-9.]/g, "");
    return parseFloat(numeric) || 0;
  }

  function handleInputChange(e: React.ChangeEvent<HTMLInputElement>) {
    const input = e.target.value;
    const parsed = parseCurrency(input);
    setDisplay(input);
    onChange(parsed);
  }

  function handleBlur() {
    setDisplay(formatCurrency(value));
  }

  return (
    <>
      <Form.Group>
        {label && <Form.Label>{label}</Form.Label>}
        <Form.Control
          type="text"
          inputMode="decimal"
          value={display}
          onChange={handleInputChange}
          onBlur={handleBlur}
          placeholder={placeholder || "$0.00"}
        />
      </Form.Group>
      <Form.Control.Feedback type="invalid">
        {errorMessage}
      </Form.Control.Feedback>
    </>
  );
};

export default CurrencyInput;
