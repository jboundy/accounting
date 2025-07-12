import CreateBudget from "../features/budget/createBudget";
import BudgetLanding from "../features/budget/pages/budgetLanding";
import Layout from "../layout/Layout";

const BudgetRoutes = {
  path: "/budget",
  element: <Layout />,
  children: [
    {
      path: "list",
      element: <BudgetLanding />,
    },
    {
      path: "create",
      element: <CreateBudget />,
    },
  ],
};

export default BudgetRoutes;
