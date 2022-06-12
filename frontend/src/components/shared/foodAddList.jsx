import { useState } from "react";

const FoodAddList = ({ foods, values, setValues }) => {
  const [nameFilter, setNameFilter] = useState("");

  const previewQuantity = (id) => {
    if (values.foodData.length === 0) {
      return 0;
    }

    var foodPicked = values.foodData.filter((f) => f.foodId === id)[0];

    if (foodPicked === null || foodPicked === undefined) {
      return 0;
    }

    return foodPicked.quantity;
  };

  const incrementFood = (id) => {
    if (values.foodData.length === 0) {
      addFood(id);
    } else {
      var newState = values;

      var foodPicked = newState.foodData.filter((f) => f.foodId === id)[0];

      if (foodPicked === null || foodPicked === undefined) {
        addFood(id);
      } else {
        foodPicked.quantity += 1;

        setValues({ ...newState });
      }
    }
  };

  const addFood = (id) => {
    var newState = values;

    newState["foodData"] = [
      ...newState["foodData"],
      { foodId: id, quantity: 1, billId: "" },
    ];

    setValues({ ...newState });
  };

  const decrementFood = (id) => {
    if (values.foodData.length > 0) {
      var newState = values;

      var foodPicked = newState.foodData.filter((f) => f.foodId === id)[0];

      if (foodPicked !== null || foodPicked !== undefined) {
        if (foodPicked.quantity === 1) {
          var newFoodData = newState.foodData.filter((x) => x.foodId !== id);
          newState.foodData = newFoodData;
        } else {
          foodPicked.quantity -= 1;
        }

        setValues({ ...newState });
      }
    }
  };

  return (
    <div className="food-addList-container">
      <div>
        <h3 className="title">Add food to bill</h3>
      </div>
      <input
        className="form-control mr-sm-2 custom-input"
        type="search"
        placeholder="Search"
        aria-label="Search"
        onChange={(e) => setNameFilter(e.target.value)}
      ></input>
      <label htmlFor="exampleFormControlSelect1">Foods</label>
      <ul className="list-group custom-input">
        {foods
          .filter(
            (x) => x.name.toLowerCase().indexOf(nameFilter.toLowerCase()) > -1
          )
          .map((food, index) => (
            <li
              key={`foodList${index}`}
              className="list-group-item d-flex justify-content-between align-items-center"
            >
              {food.name} - {food.price}лв
              <div className="food-listItem-button-container">
                <span className="badge badge-primary badge-pill food-listItem-badge">
                  {previewQuantity(food.id)}
                </span>

                <button
                  type="button"
                  className="btn btn-success btn-addFood"
                  onClick={() => incrementFood(food.id)}
                >
                  <i className="bi bi-plus-circle-dotted"></i>
                </button>
                <button
                  type="button"
                  className="btn btn-danger btn-addFood"
                  onClick={() => decrementFood(food.id)}
                >
                  <i className="bi bi-dash-circle-dotted"></i>
                </button>
              </div>
            </li>
          ))}
      </ul>
    </div>
  );
};

export default FoodAddList;
