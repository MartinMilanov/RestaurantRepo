namespace Restaurant.Mapping.Models.Reservations
{
    public class ReservationResultDto
    {
        public string Id { get; set; }

        public string ReserveeName { get; set; }

        public int PeopleCount { get; set; }

        public DateTime Date { get; set; }

        public string TableNumber { get; set; }

        public string CreatedByName { get; set; }

        public string TableId { get; set; }

        public string CreatedById { get; set; }
    }
}
