import ListView from "../shared/listView";

const CategoryList = () => {
  return (
    <ListView
      endpoint={"categories"}
      columnNames={["Name"]}
      filters={{ Name: "" }}
    />
  );
};

export default CategoryList;
