import { Outlet } from "react-router-dom";
import "./css/Layout.css";
import { Container } from "react-bootstrap";

export default function Layout() {
  return (
    <>
      <Container fluid className="ms-md-auto px-md-4">
        <Outlet />
      </Container>
    </>
  );
}
