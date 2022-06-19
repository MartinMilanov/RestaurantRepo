import ListView from "../shared/listView";

const ReservationList = () => {
  const previewFilters = (onChangeFilter) => {
    return (
      <>
        <div className="input-group mb-3" key={`$1resrtvfilter`}>
          <span className="input-group-text" id="inputGroup-sizing-default">
            Дата и час
          </span>
          <input
            type="datetime-local"
            className="form-control"
            aria-label="Sizing example input"
            aria-describedby="inputGroup-sizing-default"
            onChange={(e) => onChangeFilter("Date", e.target.value)}
          />
        </div>
        <div className="input-group mb-3" key={`$1resrtvfilter`}>
          <span className="input-group-text" id="inputGroup-sizing-default">
            Създадено от
          </span>
          <input
            type="text"
            className="form-control"
            aria-label="Sizing example input"
            aria-describedby="inputGroup-sizing-default"
            onChange={(e) => onChangeFilter("CreatedBy", e.target.value)}
          />
        </div>
      </>
    );
  };

  return (
    <ListView
      endpoint={"reservations"}
      columnNames={[
        "Reservee Name",
        "People Count",
        "Date",
        "Table Number",
        "CreatedBy",
      ]}
      previewFilters={previewFilters}
    />
  );
};

export default ReservationList;
