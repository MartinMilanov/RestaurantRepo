import { Routes, Route } from "react-router-dom";
import FoodList from "./foods/foodList";
import CategoryList from "./categories/categoryList";
import CategoryDetails from "./categories/categoryDetails";
import ReservationList from "./reservations/reservations";
import TableList from "./tables/tableList";
import BillList from "./bills/billList";

const Main = () => {
  return (
    <main
      role="main"
      className="col-md-9 ml-sm-auto col-lg-10 col-xl-10 pt-3 px-4"
    >
      <Routes>
        <Route path="foods" element={<FoodList />} />
        <Route path="categories" element={<CategoryList />} />
        <Route path="categories/details/:id" element={<CategoryDetails />} />

        <Route path="reservations" element={<ReservationList />} />
        <Route path="tables" element={<TableList />} />
        <Route path="bills" element={<BillList />} />
      </Routes>
    </main>
  );
};
export default Main;
