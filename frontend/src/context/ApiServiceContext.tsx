import React, { createContext, useContext } from "react";
import { ApiService, apiService } from "../services/apiService";

const ApiContext = createContext<ApiService | null>(null);

export const ApiProvider: React.FC<{ children: React.ReactNode }> = ({
  children,
}) => {
  return (
    <ApiContext.Provider value={apiService}>{children}</ApiContext.Provider>
  );
};

export const useApi = () => {
  const context = useContext(ApiContext);
  if (!context) {
    throw new Error("useApi must be used within an ApiProvider");
  }
  return context.getClient();
};
