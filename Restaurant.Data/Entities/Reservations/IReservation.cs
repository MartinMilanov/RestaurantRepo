using Restaurant.Data.Entities.Auth;
using Restaurant.Data.Entities.Tables;

namespace Restaurant.Data.Entities.Reservations
{
    public interface IReservation
    {
        public string ReserveeName { get; set; }
        public int PeopleCount { get; set; }
        public DateTime Date { get; set; }
        public string TableId { get; set; }
        public Table Table { get; set; }
        public string CreatedById { get; set; }
        public ApplicationUser CreatedBy { get; set; }
    }
}