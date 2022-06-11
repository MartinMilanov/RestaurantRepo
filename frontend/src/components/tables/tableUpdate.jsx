import { useState } from "react";
import { getItemById, updateItem } from "../../services/commonService";
import { useNavigate, useParams } from "react-router-dom";
import { useEffect } from "react";

const TableUpdate = () => {
  let { id } = useParams();
  const navigate = useNavigate();

  const [values, setValues] = useState({ tableNumber: "", seats: "" });

  useEffect(() => {
    const setup = async () => {
      var food = await getItemById("tables", id);

      var newState = values;
      newState.tableNumber = food.tableNumber;
      newState.seats = food.seats;

      setValues({ ...newState });
    };

    setup();
  }, []);

  const onSubmit = async (event) => {
    event.preventDefault();
    await updateItem("tables", id, values);
    navigate(-1);
  };

  const onChange = (name, value) => {
    var newState = values;

    newState[name] = value;

    setValues({ ...newState });
  };

  return (
    <>
      <h2 className="formTitle">Update table entry</h2>

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
            value={values.tableNumber}
            onChange={(e) => onChange("tableNumber", e.target.value)}
          />
          <label className="form-label">Seats</label>
          <input
            type="number"
            className="form-control custom-input"
            value={values.seats}
            onChange={(e) => onChange("seats", e.target.value)}
          />
        </div>
        <button className="btn btn-warning">Update</button>

        <button
          className="btn btn-cancel"
          type="button"
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

export default TableUpdate;
