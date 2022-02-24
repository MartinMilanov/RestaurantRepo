using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Entities.Auth
{
    public class ApplicationUserRole : IdentityRole<string>
    {
        public ApplicationUserRole()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
