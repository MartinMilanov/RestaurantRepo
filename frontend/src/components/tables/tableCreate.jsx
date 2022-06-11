import { useState } from "react";
import { createItem } from "../../services/commonService";
import { useNavigate } from "react-router-dom";

const TableCreate = () => {
  const [values, setValues] = useState({ tableNumber: "", seats: "" });
  const navigate = useNavigate();

  const onSubmit = async (event) => {
    event.preventDefault();
    await createItem("tables", values);
    navigate(-1);
  };

  const onChange = (name, value) => {
    var newState = values;

    newState[name] = value;

    setValues({ ...newState });
  };

  return (
    <>
      <h2 className="formTitle">Create table entry</h2>

      <form
        onSubmit={(event) => {
          onSubmit(event);
        }}
      >
        <div className="mb-3">
          <label className="form-label">Table Number</label>
          <input
            required={true}
            type="number"
            className="form-control custom-input"
            onChange={(e) => onChange("tableNumber", e.target.value)}
          />
          <label className="form-label">Seats</label>
          <input
            require={true}
            type="number"
            className="form-control custom-input"
            onChange={(e) => onChange("seats", e.target.value)}
          />
        </div>
        <button className="btn btn-success">Create</button>
        <button
          className="btn btn-cancel"
          onClick={() => {
            navigate(-1);
          }}
        >
          Cancel
        </button>
      </form>
    </>
  );
};

export default TableCreate;
