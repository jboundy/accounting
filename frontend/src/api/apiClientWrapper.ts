import { Client } from "./apiClient";

const client = new Client();
//TODO: will need to fill these eventually
//baseUrl: "https://your-api-url.com", // optional, or read from env
//fetch: window.fetch.bind(window),    // important for SSR or mocking

export default client;
