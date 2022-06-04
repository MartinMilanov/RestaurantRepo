import ListView from "../shared/listView";

const FoodList = () => {
  return (
    <ListView
      endpoint={"foods"}
      columnNames={["Name", "Price"]}
      filters={{ Name: "", Price: "" }}
    />
  );
};

export default FoodList;
