import { Dropdown } from "react-bootstrap";
import { useTheme } from "../../hooks/useTheme";

export function ColorModeToggle() {
  const { setTheme } = useTheme();

  return (
    <Dropdown>
      <Dropdown.Toggle variant="success" id="dropdown-basic">
        Change Theme Color
      </Dropdown.Toggle>
      <Dropdown.Menu align="end">
        <Dropdown.Item onClick={() => setTheme("light")}>Light</Dropdown.Item>
        <Dropdown.Item onClick={() => setTheme("dark")}>Dark</Dropdown.Item>
        <Dropdown.Item onClick={() => setTheme("system")}>System</Dropdown.Item>
      </Dropdown.Menu>
    </Dropdown>
  );
}
