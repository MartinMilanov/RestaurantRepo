import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { getItemById } from "../../services/commonService";
import { getItems } from "../../services/paginationService";
import FoodAddList from "../shared/foodAddList";

const BillDetails = () => {
  let { id } = useParams();
  const [values, setValues] = useState({
    isClosed: false,
    tableId: "",
    createdById: "d149839b-7999-4813-9e06-ca14d2b744ef",
    foodData: [], // {billId,foodId,quantity}
  });

  const [tables, setTables] = useState([]);
  const [foods, setFoods] = useState([]);

  const previewTotal = () => {
    var total = 0;

    values.foodData.forEach((data) => {
      var foodPrice = foods.filter((x) => x.id === data.foodId)[0].price;

      total += foodPrice * data.quantity;
    });

    return total;
  };

  const previewFoods = () => {
    if (values.foodData.length > 0) {
      return values.foodData.map((fd) => {
        var foodValues = foods.filter((x) => x.id === fd.foodId)[0];

        return (
          <li
            key={foodValues.id}
            className="list-group-item d-flex justify-content-between align-items-center"
          >
            <div>
              <span>{foodValues.name}</span>
              <span
                className="badge badge-primary badge-pill food-listItem-badge"
                style={{ marginLeft: 20 }}
              >
                {fd.quantity}
              </span>
            </div>
            <div>
              <span style={{ fontWeight: "bold" }}>
                {(foodValues.price * fd.quantity).toFixed(2)} лв
              </span>
            </div>
          </li>
        );
      });
    } else {
      return (
        <li className="list-group-item d-flex justify-content-between align-items-center list-group-item-secondary">
          <span>Няма добавени храни</span>
        </li>
      );
    }
  };

  useEffect(() => {
    const setup = async () => {
      const tablesQuery = await getItems("tables", 0, 100, "TableNumber", 1);
      const foodsQuery = await getItems("foods", 0, 100, "Name", 1);
      const billQuery = await getItemById("bills", id);

      var newState = values;
      newState.createdById = billQuery.createdById;
      newState.foodData = billQuery.foodsOrdered;
      newState.isClosed = billQuery.isClosed;
      newState.tableId = billQuery.tableId;

      setValues({ ...newState });
      setTables(tablesQuery.data.items);
      setFoods(foodsQuery.data.items);
    };

    setup();
  }, []);

  return (
    <div className="form-container">
      <h3 className="formTitle">Детайли за сметка</h3>
      <form>
        <div className="form-group">
          <label htmlFor="exampleFormControlSelect1">Затворено</label>
          <select
            required={true}
            className="form-control custom-input"
            id="exampleFormControlSelect1"
            disabled={true}
          >
            <option value={false} selected={values.isClosed === false}>
              Не
            </option>
            <option value={true} selected={values.isClosed === true}>
              Да
            </option>
          </select>
        </div>

        <div className="form-group">
          <label htmlFor="exampleFormControlSelect1">Маса</label>
          <select
            required={true}
            className="form-control custom-input"
            id="exampleFormControlSelect1"
            disabled={true}
          >
            {tables.length > 0
              ? tables.map((table) => (
                  <option
                    key={table.id}
                    value={table.id}
                    selected={table.id === values.tableId}
                  >
                    {table.tableNumber}
                  </option>
                ))
              : null}
          </select>
        </div>

        <div className="form-group">
          <label htmlFor="exampleFormControlSelect1">Храни</label>

          <ul className="list-group custom-input">{previewFoods()}</ul>
        </div>
        <hr></hr>
        <div className="total-container">
          <h4>{previewTotal().toFixed(2)} лв</h4>
        </div>
      </form>
    </div>
  );
};

export default BillDetails;
