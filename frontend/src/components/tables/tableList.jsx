import ListView from "../shared/listView";

const TableList = () => {
  return (
    <ListView
      endpoint={"tables"}
      columnNames={["Table Number", "Seats"]}
      filters={{ CreatedBy: "", Date: "" }}
    />
  );
};

export default TableList;
