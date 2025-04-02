import { Client } from "../api/apiClient";

export class ApiService {
  private apiClient: Client;

  constructor(baseUrl: string, getToken?: () => string | null) {
    this.apiClient = new Client(baseUrl, {
      fetch: async (url, options) => {
        if (getToken) {
          const token = getToken();
          if (token) {
            options = options || {};
            options.headers = {
              ...options.headers,
              Authorization: `Bearer ${token}`,
            };
          }
        }
        return fetch(url, options);
      },
    });
  }

  getClient() {
    return this.apiClient;
  }
}

export const apiService = new ApiService("http://localhost:5250", () =>
  localStorage.getItem("token")
);
