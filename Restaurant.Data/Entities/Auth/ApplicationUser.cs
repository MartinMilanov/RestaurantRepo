using Microsoft.AspNetCore.Identity;
using Restaurant.Data.Entities.Bills;
using Restaurant.Data.Entities.Reservations;

namespace Restaurant.Data.Entities.Auth
{
    public class ApplicationUser : IdentityUser<string>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public List<Reservation> CreatedReservations { get; set; }
        public List<Bill> CreatedBills { get; set; }
    }
}
