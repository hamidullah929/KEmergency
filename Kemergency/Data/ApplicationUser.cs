using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Data
{
    public class ApplicationUser: IdentityUser
    {

        public int AppUserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string NicNubmer { get; set; }
    }
}
