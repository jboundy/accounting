import CreateAccount from "../features/account/createAccount";
import Layout from "../layout/Layout";

const AccountRoutes = {
  path: "/account",
  element: <Layout />,
  children: [
    {
      path: "create",
      element: <CreateAccount />,
    },
  ],
};

export default AccountRoutes;
