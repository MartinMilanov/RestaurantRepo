using Microsoft.AspNetCore.Identity;
using Restaurant.Data.Entities.Bills;
using Restaurant.Data.Entities.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Entities.Auth
{
    public class ApplicationUser : IdentityUser<string>
    {
        public ApplicationUser()
        {
        }

        public List<Reservation> CreatedReservations { get; set; }
        public List<Bill> CreatedBills { get; set; }
    }
}
