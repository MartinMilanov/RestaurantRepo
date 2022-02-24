using Restaurant.Data.Entities.Common;
using Restaurant.Data.Entities.Reservations;

namespace Restaurant.Data.Entities.Tables
{
    public class Table : BaseEntity, ITable
    {
        public int TableNumber { get; set; }
        public int Seats { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}