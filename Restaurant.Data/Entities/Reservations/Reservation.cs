using Restaurant.Data.Entities.Common;
using Restaurant.Data.Entities.Tables;

namespace Restaurant.Data.Entities.Reservations
{
    public class Reservation : BaseEntity, IReservation
    {
        public int PeopleCount { get; set; }
        public DateTime Date { get; set; }
        public string TableId { get; set; }
        public Table Table { get; set; }
    }