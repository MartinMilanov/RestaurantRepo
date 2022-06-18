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
import BillDetails from "./bills/billDetails";
import Login from "./users/loginPage";
import { GlobalContext } from "../GlobalContext";
import { useContext } from "react";
import Unauthorized from "./shared/unauthorized";
import NotFound from "./shared/notFound";

const Main = () => {
  const { username } = useContext(GlobalContext);

  const authorize = (component) => {
    return username ? component : <Unauthorized />;
  };

  return (
    <main
      role="main"
      className="col-md-9 ml-sm-auto col-lg-10 col-xl-10 pt-3 px-4"
    >
      <Routes>
        <Route path="foods" element={authorize(<FoodList />)} />
        <Route path="foods/details/:id" element={authorize(<FoodDetails />)} />
        <Route path="foods/create" element={authorize(<FoodCreate />)} />
        <Route path="foods/update/:id" element={authorize(<FoodUpdate />)} />

        <Route path="categories" element={authorize(<CategoryList />)} />
        <Route
          path="categories/details/:id"
          element={authorize(<CategoryDetails />)}
        />
        <Route
          path="categories/create"
          element={authorize(<CategoryCreate />)}
        />
        <Route
          path="categories/update/:id"
          element={authorize(<CategoryUpdate />)}
        />

        <Route path="reservations" element={authorize(<ReservationList />)} />
        <Route
          path="reservations/details/:id"
          element={authorize(<ReservationDetails />)}
        />
        <Route
          path="reservations/create"
          element={authorize(<ReservationCreate />)}
        />
        <Route
          path="reservations/update/:id"
          element={authorize(<ReservationUpdate />)}
        />

        <Route path="tables" element={authorize(<TableList />)} />
        <Route
          path="tables/details/:id"
          element={authorize(<TableDetails />)}
        />
        <Route path="tables/create" element={authorize(<TableCreate />)} />
        <Route path="tables/update/:id" element={authorize(<TableUpdate />)} />

        <Route path="bills" element={authorize(<BillList />)} />
        <Route path="bills/create" element={authorize(<BillCreate />)} />
        <Route path="bills/update/:id" element={authorize(<BillUpdate />)} />
        <Route path="bills/details/:id" element={authorize(<BillDetails />)} />

        <Route path="/login" element={<Login />} />

        <Route path="*" element={authorize(<NotFound />)} />
      </Routes>
    </main>
  );
};
export default Main;
