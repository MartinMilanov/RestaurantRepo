import ListView from "../shared/listView";

const ReservationList = () => {
  return (
    <ListView
      endpoint={"reservations"}
      columnNames={[
        "Reservee Name",
        "People Count",
        "Date",
        "Table Id",
        "CreatedBy",
      ]}
      filters={{ CreatedBy: "", Date: "" }}
    />
  );
};

export default ReservationList;
