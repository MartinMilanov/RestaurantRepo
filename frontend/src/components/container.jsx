import Sidebar from "./navigation/sidebar";
import Main from "./main";
import { BrowserRouter } from "react-router-dom";

const Container = () => {
  return (
    <div className="container-fluid">
      <div className="row">
        <BrowserRouter>
          <Sidebar />
          <Main />
        </BrowserRouter>
      </div>
    </div>
  );
};
export default Container;
