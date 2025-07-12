import { Col, Container, Row } from "react-bootstrap";
import BudgetList from "../budgetList";

export default function BudgetLanding() {
  return (
    <Container>
      <Row>
        <Col>
          <BudgetList />
        </Col>
      </Row>
    </Container>
  );
}
