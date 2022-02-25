using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Common.Configurations.Bills;
using Restaurant.Data.Common.Configurations.Categories;
using Restaurant.Data.Common.Configurations.FoodBills;
using Restaurant.Data.Common.Configurations.Reservations;
using Restaurant.Data.Entities.Auth;
using Restaurant.Data.Entities.Bills;
using Restaurant.Data.Entities.Categories;
using Restaurant.Data.Entities.FoodBills;
using Restaurant.Data.Entities.Foods;
using Restaurant.Data.Entities.Reservations;
using Restaurant.Data.Entities.Tables;

namespace Restaurant.Data
{
    public class RestaurantDbContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, string>
    {
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FoodBill> FoodBills { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("18118164");

            base.OnModelCreating(builder);

            new FoodBillsConfiguration().Configure(builder.Entity<FoodBill>());
            new BillsConfiguration().Configure(builder.Entity<Bill>());
            new CategoriesConfiguration().Configure(builder.Entity<Category>());
            new ReservationsConfiguration().Configure(builder.Entity<Reservation>());
        }
    }
}