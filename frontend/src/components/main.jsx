import List from "./shared/list";
import ListView from "./shared/listView";

const Main = () => {
  return (
    <main
      role="main"
      className="col-md-9 ml-sm-auto col-lg-10 col-xl-10 pt-3 px-4"
    >
      <ListView
        endpoint={"foods"}
        columnNames={{ name: "hello", age: "22", hasABowl: "nobro" }}
        filters={{ name: "", price: "" }}
      />
    </main>
  );
};
export default Main;
