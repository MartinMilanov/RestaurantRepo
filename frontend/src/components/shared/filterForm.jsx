const FilterForm = ({ filters }) => {
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

  return (
    <div className="filterBlock">
      <h3>Filters</h3>
      {generateFilters()}

      <button className="btn btn-primary">Filter</button>
    </div>
  );
};
export default FilterForm;
