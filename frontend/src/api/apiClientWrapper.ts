import { Client } from "./apiClient";

const customHttp = {
  fetch: async (
    url: RequestInfo,
    init: RequestInit = {}
  ): Promise<Response> => {
    const token = localStorage.getItem("jwtToken");

    const headers = new Headers(init.headers);
    if (token) {
      headers.set("Authorization", `Bearer ${token}`);
    }

    return fetch(url, {
      ...init,
      headers,
    });
  },
};

const client = new Client(undefined, customHttp);
//TODO: will need to fill these eventually
//baseUrl: "https://your-api-url.com", // optional, or read from env
//fetch: window.fetch.bind(window),    // important for SSR or mocking

export default client;
