import { Routes, Route } from "react-router-dom";
import FoodList from "./foods/foodList";
import CategoryList from "./categories/categoryList";
import CategoryDetails from "./categories/categoryDetails";
import ReservationList from "./reservations/reservations";
import TableList from "./tables/tableList";
import BillList from "./bills/billList";
import CategoryCreate from "./categories/categoryCreate";
import CategoryUpdate from "./categories/categoryUpdate";
import FoodDetails from "./foods/foodDetails";
import FoodCreate from "./foods/foodCreate";
import FoodUpdate from "./foods/foodUpdate";
import TableDetails from "./tables/tableDetails";
import TableCreate from "./tables/tableCreate";
import TableUpdate from "./tables/tableUpdate";
import ReservationDetails from "./reservations/reservationDetails";
import ReservationCreate from "./reservations/reservationCreate";
import ReservationUpdate from "./reservations/reservationUpdate";
import BillCreate from "./bills/billCreate";
import BillUpdate from "./bills/billUpdate";

const Main = () => {
  return (
    <main
      role="main"
      className="col-md-9 ml-sm-auto col-lg-10 col-xl-10 pt-3 px-4"
    >
      <Routes>
        <Route path="foods" element={<FoodList />} />
        <Route path="foods/details/:id" element={<FoodDetails />} />
        <Route path="foods/create" element={<FoodCreate />} />
        <Route path="foods/update/:id" element={<FoodUpdate />} />

        <Route path="categories" element={<CategoryList />} />
        <Route path="categories/details/:id" element={<CategoryDetails />} />
        <Route path="categories/create" element={<CategoryCreate />} />
        <Route path="categories/update/:id" element={<CategoryUpdate />} />

        <Route path="reservations" element={<ReservationList />} />
        <Route
          path="reservations/details/:id"
          element={<ReservationDetails />}
        />
        <Route path="reservations/create" element={<ReservationCreate />} />
        <Route path="reservations/update/:id" element={<ReservationUpdate />} />

        <Route path="tables" element={<TableList />} />
        <Route path="tables/details/:id" element={<TableDetails />} />
        <Route path="tables/create" element={<TableCreate />} />
        <Route path="tables/update/:id" element={<TableUpdate />} />

        <Route path="bills" element={<BillList />} />
        <Route path="bills/create" element={<BillCreate />} />
        <Route path="bills/update/:id" element={<BillUpdate />} />
      </Routes>
    </main>
  );
};
export default Main;
