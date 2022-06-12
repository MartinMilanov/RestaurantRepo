import { useState } from "react";

const FoodAddList = ({ foods }) => {
  const [nameFilter, setNameFilter] = useState("");

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
      <label for="exampleFormControlSelect1">Foods</label>
      <ul className="list-group custom-input">
        {foods
          .filter(
            (x) => x.name.toLowerCase().indexOf(nameFilter.toLowerCase()) > -1
          )
          .map((food) => (
            <li className="list-group-item d-flex justify-content-between align-items-center">
              {food.name}
              <div>
                <button type="button" className="btn btn-success btn-addFood">
                  <i className="bi bi-plus-circle-dotted"></i>
                </button>
                <button type="button" className="btn btn-danger btn-addFood">
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
