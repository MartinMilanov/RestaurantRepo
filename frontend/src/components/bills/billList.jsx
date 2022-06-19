import ListView from "../shared/listView";

const BillList = () => {
  const previewFilters = (onChangeFilter) => {
    return (
      <>
        <div className="input-group mb-3" key={`0billfilter`}>
          <span className="input-group-text" id="inputGroup-sizing-default">
            Затворено
          </span>
          <select
            type="text"
            className="form-control"
            aria-label="Sizing example input"
            aria-describedby="inputGroup-sizing-default"
            onChange={(e) => onChangeFilter("IsClosed", e.target.value)}
          >
            <option value={true}>Да</option>
            <option value={false}>Не</option>
          </select>
        </div>
        <div className="input-group mb-3" key={`$1billfilter`}>
          <span className="input-group-text" id="inputGroup-sizing-default">
            Номер на маса
          </span>
          <input
            type="number"
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
      endpoint={"bills"}
      columnNames={[
        "Total",
        "Closed",
        "Is Closed",
        "Table Number",
        "Created By",
      ]}
      previewFilters={previewFilters}
    />
  );
};

export default BillList;
