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
      <h2 className="formTitle">Details</h2>

      <form>
        <div className="mb-3">
          <label className="form-label">Id</label>
          <input
            type="text"
            className="form-control custom-input"
            disabled={true}
            value={reservation ? reservation.id : ""}
          />
          <label className="form-label">Reservee Name</label>
          <input
            type="text"
            className="form-control custom-input"
            disabled={true}
            value={reservation ? reservation.reserveeName : ""}
          />
          <label className="form-label">PeopleCount</label>
          <input
            type="number"
            className="form-control custom-input"
            disabled={true}
            value={reservation ? reservation.peopleCount : ""}
          />
          <label className="form-label">Date</label>
          <input
            type="text"
            className="form-control custom-input"
            disabled={true}
            value={
              reservation ? new Date(reservation.date).toLocaleDateString() : ""
            }
          />

          <label className="form-label">Table Number</label>
          <input
            type="text"
            className="form-control custom-input"
            disabled={true}
            value={reservation ? reservation.tableNumber : ""}
          />

          <label className="form-label">Created By</label>
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
