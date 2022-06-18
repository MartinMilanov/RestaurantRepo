import { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { getItemById, updateItem } from "../../services/commonService";
import { getItems } from "../../services/paginationService";
import FoodAddList from "../shared/foodAddList";

const BillUpdate = () => {
  let { id } = useParams();
  const [values, setValues] = useState({
    isClosed: false,
    tableId: "",
    createdById: "d149839b-7999-4813-9e06-ca14d2b744ef",
    foodData: [], // {billId,foodId,quantity}
  });

  const [tables, setTables] = useState([]);
  const [foods, setFoods] = useState([]);

  const navigate = useNavigate();

  const onSubmit = async (event) => {
    event.preventDefault();
    await updateItem("bills", id, values);
    navigate(-1);
  };

  const onChange = (name, value) => {
    var newState = values;

    newState[name] = value;

    setValues({ ...newState });
  };

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
          <span>Все още не сте добавили храни</span>
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
      <h3 className="formTitle">Update bill entry</h3>
      <form
        onSubmit={(event) => {
          onSubmit(event);
        }}
      >
        <div className="form-group">
          <label htmlFor="exampleFormControlSelect1">Is closed</label>
          <select
            required={true}
            className="form-control custom-input"
            id="exampleFormControlSelect1"
            onChange={(e) =>
              onChange("isClosed", e.target.value === "false" ? false : true)
            }
          >
            <option value={false} selected={values.isClosed === false}>
              False
            </option>
            <option value={true} selected={values.isClosed === true}>
              True
            </option>
          </select>
        </div>

        <div className="form-group">
          <label htmlFor="exampleFormControlSelect1">Table</label>
          <select
            required={true}
            className="form-control custom-input"
            id="exampleFormControlSelect1"
            onChange={(e) => onChange("tableId", e.target.value)}
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
          <div className={"foodListBtnLabelContainer custom-input"}>
            <button
              type="button"
              className="btn btn-primary"
              data-toggle="modal"
              data-target=".bd-example-modal-lg"
            >
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="16"
                height="16"
                fill="currentColor"
                className="bi bi-plus-circle-dotted"
                viewBox="0 0 16 16"
              >
                <path d="M8 0c-.176 0-.35.006-.523.017l.064.998a7.117 7.117 0 0 1 .918 0l.064-.998A8.113 8.113 0 0 0 8 0zM6.44.152c-.346.069-.684.16-1.012.27l.321.948c.287-.098.582-.177.884-.237L6.44.153zm4.132.271a7.946 7.946 0 0 0-1.011-.27l-.194.98c.302.06.597.14.884.237l.321-.947zm1.873.925a8 8 0 0 0-.906-.524l-.443.896c.275.136.54.29.793.459l.556-.831zM4.46.824c-.314.155-.616.33-.905.524l.556.83a7.07 7.07 0 0 1 .793-.458L4.46.824zM2.725 1.985c-.262.23-.51.478-.74.74l.752.66c.202-.23.418-.446.648-.648l-.66-.752zm11.29.74a8.058 8.058 0 0 0-.74-.74l-.66.752c.23.202.447.418.648.648l.752-.66zm1.161 1.735a7.98 7.98 0 0 0-.524-.905l-.83.556c.169.253.322.518.458.793l.896-.443zM1.348 3.555c-.194.289-.37.591-.524.906l.896.443c.136-.275.29-.54.459-.793l-.831-.556zM.423 5.428a7.945 7.945 0 0 0-.27 1.011l.98.194c.06-.302.14-.597.237-.884l-.947-.321zM15.848 6.44a7.943 7.943 0 0 0-.27-1.012l-.948.321c.098.287.177.582.237.884l.98-.194zM.017 7.477a8.113 8.113 0 0 0 0 1.046l.998-.064a7.117 7.117 0 0 1 0-.918l-.998-.064zM16 8a8.1 8.1 0 0 0-.017-.523l-.998.064a7.11 7.11 0 0 1 0 .918l.998.064A8.1 8.1 0 0 0 16 8zM.152 9.56c.069.346.16.684.27 1.012l.948-.321a6.944 6.944 0 0 1-.237-.884l-.98.194zm15.425 1.012c.112-.328.202-.666.27-1.011l-.98-.194c-.06.302-.14.597-.237.884l.947.321zM.824 11.54a8 8 0 0 0 .524.905l.83-.556a6.999 6.999 0 0 1-.458-.793l-.896.443zm13.828.905c.194-.289.37-.591.524-.906l-.896-.443c-.136.275-.29.54-.459.793l.831.556zm-12.667.83c.23.262.478.51.74.74l.66-.752a7.047 7.047 0 0 1-.648-.648l-.752.66zm11.29.74c.262-.23.51-.478.74-.74l-.752-.66c-.201.23-.418.447-.648.648l.66.752zm-1.735 1.161c.314-.155.616-.33.905-.524l-.556-.83a7.07 7.07 0 0 1-.793.458l.443.896zm-7.985-.524c.289.194.591.37.906.524l.443-.896a6.998 6.998 0 0 1-.793-.459l-.556.831zm1.873.925c.328.112.666.202 1.011.27l.194-.98a6.953 6.953 0 0 1-.884-.237l-.321.947zm4.132.271a7.944 7.944 0 0 0 1.012-.27l-.321-.948a6.954 6.954 0 0 1-.884.237l.194.98zm-2.083.135a8.1 8.1 0 0 0 1.046 0l-.064-.998a7.11 7.11 0 0 1-.918 0l-.064.998zM8.5 4.5a.5.5 0 0 0-1 0v3h-3a.5.5 0 0 0 0 1h3v3a.5.5 0 0 0 1 0v-3h3a.5.5 0 0 0 0-1h-3v-3z"></path>
              </svg>
              <span style={{ marginLeft: 7 }}> Manage Orders </span>
            </button>
          </div>
          <label htmlFor="exampleFormControlSelect1">Foods</label>

          <div
            className="modal fade bd-example-modal-lg"
            tabindex="-1"
            role="dialog"
            aria-labelledby="myLargeModalLabel"
            aria-hidden="true"
          >
            <div className="modal-dialog modal-lg">
              <div className="modal-content">
                <div className="modal-header modal-food-title">
                  <h5 className="modal-title " id="exampleModalLabel">
                    Добавяне на храна
                  </h5>
                  <button
                    type="button"
                    className="close"
                    data-dismiss="modal"
                    aria-label="Close"
                  >
                    <span aria-hidden="true">&times;</span>
                  </button>
                </div>
                <div className="modal-body">
                  <FoodAddList
                    foods={foods}
                    values={values}
                    setValues={setValues}
                  />
                </div>
                <div className="modal-footer">
                  <button
                    type="button"
                    className="btn btn-secondary"
                    data-dismiss="modal"
                  >
                    Close
                  </button>
                </div>
              </div>
            </div>
          </div>
          <ul className="list-group custom-input">{previewFoods()}</ul>
        </div>
        <hr></hr>
        <div className="total-container">
          <h4>{previewTotal().toFixed(2)} лв</h4>
        </div>
        <button className="btn btn-warning">Update</button>
      </form>
    </div>
  );
};

export default BillUpdate;
