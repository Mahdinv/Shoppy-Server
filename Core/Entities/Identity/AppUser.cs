using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Identity
{
    public class AppUser : IdentityUser /*tozihat safe 9 mored 9*/
    {
        public string DisplayName { get; set; }
        public Address Address { get; set; }
    }
}
