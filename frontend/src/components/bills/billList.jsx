import ListView from "../shared/listView";

const BillList = () => {
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
      filters={{ IsClosed: "", TableNumber: "" }}
    />
  );
};

export default BillList;
