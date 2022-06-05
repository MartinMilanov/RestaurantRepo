import { useEffect, useState } from "react";
const FilterForm = ({ filters }) => {
  const [activeFilterKvpArr, setActiveFilterKvpArr] = useState([
    ["Name", "Todd"],
    ["Vanish", "Todd"],
  ]);

  const generateFilters = () => {
    var dataKvpFilters = [];

    dataKvpFilters = Object.entries(filters);

    return dataKvpFilters.map((kvp, index) => (
      <div className="input-group mb-3" key={`${index}filter`}>
        <span className="input-group-text" id="inputGroup-sizing-default">
          {kvp[0]}
        </span>
        <input
          type="text"
          className="form-control"
          aria-label="Sizing example input"
          aria-describedby="inputGroup-sizing-default"
        />
      </div>
    ));
  };

  const generateActiveFilterButtons = () => {
    return activeFilterKvpArr.map((x, index) => (
      <button
        key={`${index}-filterRemove`}
        type="button"
        class="btn btn-primary btn-filter-remove"
        onClick={() => removeFilter(x[0])}
      >
        {x[0]} : {x[1]} <span class="badge badge-light">x</span>
      </button>
    ));
  };

  const removeFilter = (filterName) => {
    if (activeFilterKvpArr.length > 0) {
      var newState = activeFilterKvpArr;
      var indexOfFilter = activeFilterKvpArr.findIndex(
        (x) => x[0] == filterName
      );
      newState.splice(indexOfFilter, 1);
      setActiveFilterKvpArr([...newState]);
    }
  };

  return (
    <div className="filterBlock">
      <h3>Filters</h3>

      {generateFilters()}

      <button className="btn btn-primary">Filter</button>

      <div className="btn-filter-container">
        {generateActiveFilterButtons()}
      </div>
    </div>
  );
};
export default FilterForm;
