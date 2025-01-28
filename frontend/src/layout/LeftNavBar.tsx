import { Container, Nav, Navbar, Offcanvas } from "react-bootstrap";
import "./LeftNavBar.css";

export function LeftNavBar() {
  return (
    <>
      <Navbar expand="sm" className="bg-body-tertiary sticky-nav">
        <Container fluid style={{ height: "100%" }}>
          <Navbar.Toggle aria-controls={`offcanvasNavbar-expand-sm`} />
          <Navbar.Offcanvas
            id={`offcanvasNavbar-expand-sm`}
            aria-labelledby={`offcanvasNavbarLabel-expand-sm`}
            placement="start"
          >
            <Offcanvas.Header closeButton>
              <Offcanvas.Title id={`offcanvasNavbarLabel-expand-sm`}>
                {/* this is where some icon would be avatar */}
              </Offcanvas.Title>
            </Offcanvas.Header>
            <Offcanvas.Body>
              <Nav className="justify-content-end flex-grow-1 pe-3">
                <Nav.Link href="/">Home WITH MORE TEXT TO SEE IT</Nav.Link>
              </Nav>
            </Offcanvas.Body>
          </Navbar.Offcanvas>
        </Container>
      </Navbar>
    </>
  );
}
