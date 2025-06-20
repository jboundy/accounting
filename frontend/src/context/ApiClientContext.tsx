// apiClientContext.tsx
import React, { createContext, useContext } from "react";
import { Client } from "../api/apiClient";
import client from "../api/apiClientWrapper";

const ApiClientContext = createContext<Client | undefined>(undefined);

export const ApiClientProvider = ({
  children,
}: {
  children: React.ReactNode;
}) => {
  return (
    <ApiClientContext.Provider value={client}>
      {children}
    </ApiClientContext.Provider>
  );
};

export const useApiClient = (): Client => {
  const context = useContext(ApiClientContext);
  if (!context)
    throw new Error("useApiClient must be used within ApiClientProvider");
  return context;
};
