using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Entities.Auth;

namespace Restaurant.Data
{
    public class RestaurantDbContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, string>
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
                
        }
    }
}