import { Table } from "react-bootstrap";
import { useEffect, useState } from "react";
import { AccountingApiFeaturesBudgetsGetBudgetsResponse } from "../../api/apiClient";
import { useApiClient } from "../../context/ApiClientContext";

export default function CreateBudget() {
  const apiClient = useApiClient();
  const [budgets, setBudgets] =
    useState<AccountingApiFeaturesBudgetsGetBudgetsResponse>();

  async function getData() {
    const response =
      await apiClient.accountingApiFeaturesBudgetsGetBudgetsEndpoint(1);
    setBudgets(response);
  }

  useEffect(() => {
    getData();
  });
  return (
    <Table striped bordered hover responsive>
      <thead>
        <tr>
          <th>Name</th>
          <th>Expected Amount</th>
          <th>Actual Amount</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        {budgets?.budgets?.map((x) => (
          <>
            <tr>{x.name}</tr>
            <tr>{x.expectedAmountToSpend}</tr>
            <tr>{x.actualAmountSpent}</tr>
            <tr></tr>
          </>
        ))}
      </tbody>
    </Table>
  );
}
