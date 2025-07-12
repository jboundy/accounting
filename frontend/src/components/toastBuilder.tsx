import { ToastContainer } from "react-bootstrap";
import Toast from "react-bootstrap/Toast";

interface ToastProps {
  variant: string;
}

function ToastBuilder({ variant }: ToastProps) {
  return (
    <ToastContainer className="p-3" position={"top-end"} style={{ zIndex: 1 }}>
      <Toast bg={variant.toLowerCase()}>
        <Toast.Header closeButton={true}></Toast.Header>
        <Toast.Body>Hello, world! This is a toast message.</Toast.Body>
      </Toast>
    </ToastContainer>
  );
}

export default ToastBuilder;
