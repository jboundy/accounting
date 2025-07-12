import { Col, Container, Row } from "react-bootstrap";
import Login from "../login";

export default function LoginLanding() {
  return (
    <Container>
      <Row>
        <Col>
          <Login />
        </Col>
      </Row>
    </Container>
  );
}
