using Restaurant.Data.Entities.Bills;
using Restaurant.Data.Entities.Reservations;

namespace Restaurant.Data.Entities.Tables
{
    public interface ITable
    {
        public int TableNumber { get; set; }
        public int Seats { get; set; }
        public List<Bill> Bills { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}