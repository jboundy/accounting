import CreateBudget from "../features/budget/createBudget";
import Layout from "../layout/Layout";

const BudgetRoutes = {
  path: "/budget",
  element: <Layout />,
  children: [
    {
      path: "create",
      element: <CreateBudget />,
    },
  ],
};

export default BudgetRoutes;
