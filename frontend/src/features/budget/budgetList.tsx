import { Table } from "react-bootstrap";
import { useEffect, useState } from "react";
import {
  AccountingApiFeaturesBudgetsGetBudgetsResponse,
  IEntitiesBudget,
} from "../../api/apiClient";
import { useApiClient } from "../../context/ApiClientContext";
import { useSelector } from "react-redux";
import { RootState } from "../../state/Store";
import { PencilFill } from "react-bootstrap-icons";
import EditBudgetDialog from "./dialogs/editBudgetDialog";

export default function BudgetList() {
  const apiClient = useApiClient();
  const userId = useSelector((state: RootState) => state.account.userId);
  const [budgets, setBudgets] =
    useState<AccountingApiFeaturesBudgetsGetBudgetsResponse>();
  const [editingBudget, setEditingBudget] = useState<IEntitiesBudget | null>(
    null
  );

  async function getData() {
    const response =
      await apiClient.accountingApiFeaturesBudgetsGetBudgetsEndpoint(userId!);
    setBudgets(response);
  }

  function editBudget(id: number) {
    const budget = budgets?.budgets?.find((b) => b.id === id);
    if (budget) {
      setEditingBudget(budget);
    }
  }

  useEffect(() => {
    if (userId) {
      getData();
    }
  }, [userId]);
  return (
    <>
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
            <tr key={x.id}>
              <td>{x.name}</td>
              <td>{x.expectedAmountToSpend}</td>
              <td>{x.actualAmountSpent}</td>
              <td>
                <PencilFill
                  color="royalblue"
                  onClick={() => editBudget(x.id!)}
                />
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
      {editingBudget && (
        <EditBudgetDialog
          budget={editingBudget}
          handleClose={() => setEditingBudget(null)}
        />
      )}
    </>
  );
}
