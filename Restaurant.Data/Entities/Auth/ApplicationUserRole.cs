using Microsoft.AspNetCore.Identity;

namespace Restaurant.Data.Entities.Auth
{
    public class ApplicationUserRole : IdentityRole<string>
    {
        public ApplicationUserRole()
        {
        }
        public ApplicationUserRole(string identityRoleName) :base(identityRoleName)
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
