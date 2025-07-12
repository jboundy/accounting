import { Modal } from "react-bootstrap";
import { IEntitiesBudget } from "../../../api/apiClient";
import EditBudget from "../editBudget";

interface EditBudgetDialogProps {
  budget: IEntitiesBudget;
  handleClose: () => void;
}

export default function EditBudgetDialog({
  budget,
  handleClose,
}: EditBudgetDialogProps) {
  return (
    <Modal
      show={true}
      onHide={handleClose}
      size="lg"
      aria-labelledby="contained-modal-title-vcenter"
      centered
    >
      <Modal.Header closeButton>
        <Modal.Title>Edit Budget</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <EditBudget budget={budget} callback={handleClose} />
      </Modal.Body>
    </Modal>
  );
}
