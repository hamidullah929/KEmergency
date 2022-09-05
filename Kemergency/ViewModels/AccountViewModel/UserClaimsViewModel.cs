using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.ViewModels.AccountViewModel
{
    public class UserClaimsViewModel
    {
        public UserClaimsViewModel()
        {
            Cliams = new List<UserCliam>();
        }
        public string userId { get; set; }
        public List<UserCliam> Cliams { get; set; }
    }
}
