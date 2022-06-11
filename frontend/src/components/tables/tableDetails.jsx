import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getItemById } from "../../services/commonService";

const TableDetails = () => {
  let { id } = useParams();
  const [table, setTable] = useState(null);

  useEffect(() => {
    const setup = async () => {
      var table = await getItemById("tables", id);

      setTable(table);
    };

    setup();
  }, []);

  return (
    <>
      <h2 className="formTitle">Details</h2>

      <form>
        <div className="mb-3">
          <label className="form-label">Id</label>
          <input
            type="text"
            className="form-control custom-input"
            disabled={true}
            value={table ? table.id : ""}
          />
          <label className="form-label">Table Number</label>
          <input
            type="text"
            className="form-control custom-input"
            disabled={true}
            value={table ? table.tableNumber : ""}
          />
          <label className="form-label">Seats</label>
          <input
            type="number"
            className="form-control custom-input"
            disabled={true}
            value={table ? table.seats : ""}
          />
        </div>
      </form>
    </>
  );
};

export default TableDetails;
