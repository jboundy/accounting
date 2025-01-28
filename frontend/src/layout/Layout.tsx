import { Outlet } from "react-router-dom";
import { LeftNavBar } from "./LeftNavBar";
import { Container } from "react-bootstrap";
import "./Layout.css";

export default function Layout() {
  return (
    <Container fluid className="layout-container">
      <LeftNavBar />
      <Container fluid className="content-container">
        <Outlet />
      </Container>
    </Container>
  );
}
