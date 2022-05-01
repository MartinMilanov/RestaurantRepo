using Restaurant.Data.Entities.Reservations;

namespace Restaurant.Data.Common.Persistance.Repositories
{
    public class ReservationRepository : Repository<Reservation>
    {
        public ReservationRepository(RestaurantDbContext context) : base(context)
        {
        }
    }
}
