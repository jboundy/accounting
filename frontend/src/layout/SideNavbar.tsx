import { useState } from "react";
import { Offcanvas, Nav } from "react-bootstrap";
import { NavLink } from "react-router-dom";
import "./css/SideNavbar.css";
import "bootstrap/dist/css/bootstrap.min.css";

const SideNavbar = () => {
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const items = [
    { path: "/budget/create", title: "Budget", icon: "bi-house-door" },
    { path: "/console/apps", title: "Applications", icon: "bi-layers" },
    { path: "/console/users", title: "Users", icon: "bi-people" },
    { path: "/console/settings", title: "Settings", icon: "bi-gear" },
  ];

  return (
    <>
      <button className="btn btn-primary" onClick={handleShow}>
        Open Sidebar
      </button>

      <Offcanvas show={show} onHide={handleClose} placement="start">
        <Offcanvas.Header closeButton>
          <Offcanvas.Title>Menu</Offcanvas.Title>
        </Offcanvas.Header>
        <Offcanvas.Body>
          <Nav className="flex-column">
            {items.map((item, i) => (
              <NavLink
                key={i}
                to={item.path}
                className={({ isActive }) =>
                  `d-flex align-items-center p-2 rounded-lg text-gray-700 hover:bg-gray-200 transition ${
                    isActive ? "bg-gray-300 font-semibold" : ""
                  }`
                }
                end
              >
                <i className={`bi ${item.icon} text-lg mr-2`} />
                {item.title}
              </NavLink>
            ))}
          </Nav>
        </Offcanvas.Body>
      </Offcanvas>
    </>
  );
};

export default SideNavbar;
