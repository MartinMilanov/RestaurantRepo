﻿namespace Restaurant.Mapping.Models.Reservations
{
    public class ReservationResultDto
    {
        public string ReserveeName { get; set; }

        public int PeopleCount { get; set; }

        public DateTime Date { get; set; }

        public string TableId { get; set; }

        public string CreatedByName { get; set; }
    }
}