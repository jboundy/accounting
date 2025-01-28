import { useRoutes } from "react-router-dom";
import BudgetRoutes from "./BudgetRoutes";
import IndexRoutes from "./IndexRoutes";

export default function MainRoutes() {
  return useRoutes([IndexRoutes, BudgetRoutes]);
}
