import { useState } from "react";
import { getItemById, updateItem } from "../../services/commonService";
import { useNavigate, useParams } from "react-router-dom";
import { useEffect } from "react";
import { getItems } from "../../services/paginationService";

const ReservationUpdate = () => {
  let { id } = useParams();
  const navigate = useNavigate();

  const [values, setValues] = useState({
    reserveeName: "",
    peopleCount: "",
    date: "",
    tableId: "",
    createdById: "",
  });

  const [tables, setTables] = useState([]);

  useEffect(() => {
    const setup = async () => {
      var reservation = await getItemById("reservations", id);
      const tablesQuery = await getItems("tables", 0, 100, "TableNumber", 1);

      var newState = values;
      newState.reserveeName = reservation.reserveeName;
      newState.peopleCount = reservation.peopleCount;
      newState.date = reservation.date;
      newState.tableId = reservation.tableId;
      newState.createdById = reservation.createdById;

      setValues({ ...newState });

      setTables(tablesQuery.data.items);
    };

    setup();
  }, []);

  const onSubmit = async (event) => {
    event.preventDefault();
    await updateItem("reservations", id, values);
    navigate(-1);
  };

  const onChange = (name, value) => {
    var newState = values;

    newState[name] = value;

    setValues({ ...newState });
  };

  return (
    <>
      <h2 className="formTitle">Update reservation entry</h2>

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
            value={values.reserveeName}
            onChange={(e) => onChange("reserveeName", e.target.value)}
          />
          <label className="form-label">People Count</label>
          <input
            type="text"
            className="form-control custom-input"
            pattern="^\d*(\.\d{0,2})?$"
            value={values.peopleCount}
            onChange={(e) => onChange("peopleCount", e.target.value)}
          />
          <label className="form-label">Date</label>
          <input
            type="datetime-local"
            className="form-control custom-input"
            pattern="^\d*(\.\d{0,2})?$"
            value={values.date}
            onChange={(e) => onChange("date", e.target.value)}
          />
          <div className="form-group">
            <label htmlFor="exampleFormControlSelect1">Table</label>
            <select
              className="form-control custom-input"
              id="exampleFormControlSelect1"
              onChange={(e) => onChange("tableId", e.target.value)}
            >
              <option value="">None</option>
              {tables.length > 0
                ? tables.map((table) => (
                    <option
                      key={table.id}
                      value={table.id}
                      selected={values.tableId === table.id}
                    >
                      {table.tableNumber}
                    </option>
                  ))
                : null}
            </select>
          </div>
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

export default ReservationUpdate;
