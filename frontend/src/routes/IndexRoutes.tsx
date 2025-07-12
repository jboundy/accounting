import CreateAccount from "../features/account/createAccount";
import LoginLanding from "../features/account/pages/loginLanding";
import Layout from "../layout/Layout";

const IndexRoutes = {
  path: "/",
  element: <Layout />,
  children: [
    {
      path: "login",
      element: <LoginLanding />,
    },
    {
      path: "create",
      element: <CreateAccount />,
    },
  ],
};

export default IndexRoutes;
