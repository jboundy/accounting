import { BrowserRouter } from "react-router-dom";
import "./App.css";
import MainRoutes from "./routes/MainRoutes";
import { ApiClientProvider } from "./context/ApiClientContext";

function App() {
  return (
    <BrowserRouter>
      <ApiClientProvider>
        <MainRoutes />
      </ApiClientProvider>
    </BrowserRouter>
  );
}

export default App;
