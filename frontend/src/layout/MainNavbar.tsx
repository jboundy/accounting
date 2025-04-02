import { NavLink } from "react-router-dom";
import { Container, Nav, Navbar } from "react-bootstrap";
import "./css/MainNavbar.css";

function MainNavbar() {
  const items = [
    { path: "/", title: "Home" },
    { path: "/login", title: "Login" },
    { path: "/logout", title: "Logout" },
    { path: "/signup", title: "Signup" },
  ];

  return (
    <Navbar bg="dark" variant="dark" expand="lg" fixed="top">
      <Container fluid>
        <Navbar.Toggle aria-controls="navbarMenu" />
        <Navbar.Collapse id="navbarMenu">
          <Nav className="me-auto">
            {items.map((item, i) => (
              <Nav.Link key={i} as={NavLink} to={item.path}>
                {item.title}
              </Nav.Link>
            ))}
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}

export default MainNavbar;
