import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getItemById } from "../../services/commonService";

const ReservationDetails = () => {
  let { id } = useParams();
  const [reservation, setReservation] = useState(null);

  useEffect(() => {
    const setup = async () => {
      var reservation = await getItemById("reservations", id);

      setReservation(reservation);
    };

    setup();
  }, []);

  return (
    <>
      <h2 className="formTitle">Детайли за резервация</h2>

      <form>
        <div className="mb-3">
          <label className="form-label">Id</label>
          <input
            type="text"
            className="form-control custom-input"
            disabled={true}
            value={reservation ? reservation.id : ""}
          />
          <label className="form-label">Име на резервиращия</label>
          <input
            type="text"
            className="form-control custom-input"
            disabled={true}
            value={reservation ? reservation.reserveeName : ""}
          />
          <label className="form-label">Брой души</label>
          <input
            type="number"
            className="form-control custom-input"
            disabled={true}
            value={reservation ? reservation.peopleCount : ""}
          />
          <label className="form-label">Дата и час</label>
          <input
            type="text"
            className="form-control custom-input"
            disabled={true}
            value={
              reservation ? new Date(reservation.date).toLocaleDateString() : ""
            }
          />

          <label className="form-label">Номер на маса</label>
          <input
            type="text"
            className="form-control custom-input"
            disabled={true}
            value={reservation ? reservation.tableNumber : ""}
          />

          <label className="form-label">Създаден от</label>
          <input
            type="text"
            className="form-control custom-input"
            disabled={true}
            value={reservation ? reservation.createdByName : ""}
          />
        </div>
      </form>
    </>
  );
};

export default ReservationDetails;
