import { useState } from "react";
const FilterForm = ({ setFilterString, previewFilters }) => {
  const [activeFilterKvpArr, setActiveFilterKvpArr] = useState([]);
  const [temporaryFilterKvpArr, setTemporaryFilterKvpArr] = useState([]);

  const generateActiveFilterButtons = () => {
    return activeFilterKvpArr.map((x, index) => (
      <button
        key={`${index}-filterRemove`}
        type="button"
        className="btn btn-secondary btn-filter-remove"
        onClick={() => removeFilter(x[0])}
      >
        {x[0]} : {x[1]} <span className="badge badge-light">x</span>
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
      setFilterString(generateQueryString(newState));
    }
  };

  const onChangeFilter = (filterName, filterValue) => {
    if (temporaryFilterKvpArr.indexOf((x) => x[0] === filterName) === -1) {
      let newState = temporaryFilterKvpArr;
      newState.push([filterName, filterValue]);

      setTemporaryFilterKvpArr([...newState]);
    } else {
      var index = temporaryFilterKvpArr.findIndex((x) => x[0] === filterName);
      let newState = temporaryFilterKvpArr;
      temporaryFilterKvpArr.splice(index, 1);
      newState.push([filterName, filterValue]);

      setTemporaryFilterKvpArr([...newState]);
    }
  };

  const generateQueryString = (kvpFilters) => {
    var queryString = "";

    queryString = kvpFilters.map((kvp) => `${kvp[0]}=${kvp[1]}`).join("&");

    return queryString;
  };

  const applyTemporaryFilters = () => {
    var newState = activeFilterKvpArr;

    temporaryFilterKvpArr.forEach((kvp) => {
      var key = kvp[0];
      var value = kvp[1];

      var index = newState.findIndex((x) => x[0] == key);

      if (index !== -1) {
        newState.splice(index, 1);
      }

      newState.push([key, value]);
    });

    setFilterString(generateQueryString(newState));
    setActiveFilterKvpArr([...newState]);
  };

  return (
    <div className="filterBlock">
      <h3>Филтри</h3>

      {previewFilters(onChangeFilter)}

      <button
        className="btn btn-primary"
        onClick={() => applyTemporaryFilters()}
      >
        Филтрирай
      </button>

      <div className="btn-filter-container">
        {generateActiveFilterButtons()}
      </div>
    </div>
  );
};
export default FilterForm;
