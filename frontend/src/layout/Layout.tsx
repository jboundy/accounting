import { Outlet } from "react-router-dom";
import "./css/Layout.css";
import { Container } from "react-bootstrap";
import SideNavbar from "./SideNavbar";

export default function Layout() {
  return (
    <>
      <SideNavbar />
      <Container fluid className="ms-md-auto px-md-4">
        <Outlet />
      </Container>
    </>
  );
}
