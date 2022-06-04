import List from "./shared/list";

const Main = () => {
  const columnNames = { name: "hello", age: "22", hasABowl: "nobro" };
  const data = [
    { id: "@222", name: "hello", age: "22", hasABowl: "nobro" },
    { id: "@222", name: "sss", age: "22", hasABowl: "nobro" },
  ];
  return (
    <main
      role="main"
      className="col-md-9 ml-sm-auto col-lg-10 col-xl-10 pt-3 px-4"
    >
      <List columnNames={columnNames} data={data} />
    </main>
  );
};
export default Main;
