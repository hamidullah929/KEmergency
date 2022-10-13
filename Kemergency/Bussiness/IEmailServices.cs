using Kemergency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Bussiness
{
   public  interface IEmailServices
    {
        bool sendEmail(Message message);
    }
}
