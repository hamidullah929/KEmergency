using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kemergency.ViewModels.AccountViewModel
{
    public class ClaimsStore
    {
        public static List<Claim> allCliam = new List<Claim>()
        {
            new Claim ("Create Role","Create Role"),
            new Claim("Edit Role","Edit Role"),
            new Claim("Delete Role","Delete Role")
        };
    }
}
