import Sidebar from "./navigation/sidebar";
import Main from "./main";

const Container = () => {
  return (
    <div className="container-fluid">
      <div className="row">
        <Sidebar />
        <Main />
      </div>
    </div>
  );
};
export default Container;
