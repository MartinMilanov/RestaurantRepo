using Restaurant.Data.Entities.Auth;

namespace Restaurant.Data.Common.Persistance.Repositories
{
    public class UserRepository : Repository<ApplicationUser>
    {
        public UserRepository(RestaurantDbContext context) : base(context)
        {
        }
    }
}
