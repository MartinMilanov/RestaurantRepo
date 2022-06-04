import Sidebar from "./navigation/sidebar";
const Container = () => {
  return (
    <div className="container-fluid">
      <div className="row">
        <Sidebar />
      </div>
    </div>
  );
};
export default Container;
