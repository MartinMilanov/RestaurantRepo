import ListView from "../shared/listView";

const TableList = () => {
  const previewFilters = (onChangeFilter) => {
    return (
      <>
        <div className="input-group mb-3" key={`$1tblfilter`}>
          <span className="input-group-text" id="inputGroup-sizing-default">
            Брой места
          </span>
          <input
            type="number"
            className="form-control"
            aria-label="Sizing example input"
            aria-describedby="inputGroup-sizing-default"
            onChange={(e) => onChangeFilter("Seats", e.target.value)}
          />
        </div>
        <div className="input-group mb-3" key={`$1tblfilter`}>
          <span className="input-group-text" id="inputGroup-sizing-default">
            Номер на маса
          </span>
          <input
            type="text"
            className="form-control"
            aria-label="Sizing example input"
            aria-describedby="inputGroup-sizing-default"
            onChange={(e) => onChangeFilter("TableNumber", e.target.value)}
          />
        </div>
      </>
    );
  };

  return (
    <ListView
      endpoint={"tables"}
      columnNames={["Table Number", "Seats"]}
      previewFilters={previewFilters}
    />
  );
};

export default TableList;
