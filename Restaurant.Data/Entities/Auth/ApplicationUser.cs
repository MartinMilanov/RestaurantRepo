using Microsoft.AspNetCore.Identity;
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
    }
}
