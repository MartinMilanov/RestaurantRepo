import ListView from "../shared/listView";

const CategoryList = () => {
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
      </>
    );
  };

  return (
    <ListView
      endpoint={"categories"}
      columnNames={["Name"]}
      previewFilters={previewFilters}
    />
  );
};

export default CategoryList;
