import ListView from "../shared/listView";

const FoodList = () => {
  const previewFilters = (onChangeFilter) => {
    return (
      <>
        <div className="input-group mb-3" key={`$1billfilter`}>
          <span className="input-group-text" id="inputGroup-sizing-default">
            Име
          </span>
          <input
            type="text"
            className="form-control"
            aria-label="Sizing example input"
            aria-describedby="inputGroup-sizing-default"
            onChange={(e) => onChangeFilter("Name", e.target.value)}
          />
        </div>
        <div className="input-group mb-3" key={`$1billfilter`}>
          <span className="input-group-text" id="inputGroup-sizing-default">
            Цена
          </span>
          <input
            type="number"
            className="form-control"
            aria-label="Sizing example input"
            aria-describedby="inputGroup-sizing-default"
            onChange={(e) => onChangeFilter("Price", e.target.value)}
          />
        </div>
      </>
    );
  };

  return (
    <ListView
      endpoint={"foods"}
      columnNames={["Name", "Price"]}
      previewFilters={previewFilters}
    />
  );
};

export default FoodList;
