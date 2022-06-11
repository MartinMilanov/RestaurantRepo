import { useState } from "react";
import { createItem } from "../../services/commonService";
import { useNavigate } from "react-router-dom";
import { useEffect } from "react";
import { getItems } from "../../services/paginationService";

const ReservationCreate = () => {
  const [values, setValues] = useState({
    reserveeName: "",
    peopleCount: "",
    date: "",
    tableId: "",
    createdById: "d149839b-7999-4813-9e06-ca14d2b744ef",
  });
  const [tables, setTables] = useState([]);

  useEffect(() => {
    const setup = async () => {
      const tablesQuery = await getItems("tables", 0, 100, "TableNumber", 1);

      setTables(tablesQuery.data.items);
    };

    setup();
  }, []);

  const navigate = useNavigate();

  const onSubmit = async (event) => {
    event.preventDefault();
    await createItem("reservations", values);
    navigate(-1);
  };

  const onChange = (name, value) => {
    var newState = values;

    newState[name] = value;

    setValues({ ...newState });
  };

  return (
    <>
      <h2 className="formTitle">Create reservation entry</h2>

      <form
        onSubmit={(event) => {
          onSubmit(event);
        }}
      >
        <div className="mb-3">
          <label className="form-label">Reservee Name</label>
          <input
            required={true}
            type="text"
            className="form-control custom-input"
            onChange={(e) => onChange("reserveeName", e.target.value)}
          />
          <label className="form-label">People Count</label>
          <input
            type="text"
            className="form-control custom-input"
            pattern="^\d*(\.\d{0,2})?$"
            onChange={(e) => onChange("peopleCount", e.target.value)}
          />
          <label className="form-label">Date</label>
          <input
            type="datetime-local"
            className="form-control custom-input"
            pattern="^\d*(\.\d{0,2})?$"
            onChange={(e) => onChange("date", e.target.value)}
          />
          <div className="form-group">
            <label for="exampleFormControlSelect1">Table</label>
            <select
              className="form-control custom-input"
              id="exampleFormControlSelect1"
              onChange={(e) => onChange("tableId", e.target.value)}
            >
              <option value="">None</option>
              {tables.length > 0
                ? tables.map((table) => (
                    <option key={table.id} value={table.id}>
                      {table.tableNumber}
                    </option>
                  ))
                : null}
            </select>
          </div>
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

export default ReservationCreate;
