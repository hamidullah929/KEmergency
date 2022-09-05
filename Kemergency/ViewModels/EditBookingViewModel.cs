using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.ViewModels
{
    public class EditBookingViewModel
    {
        public int Id { get; set; }
       
        public string MyusersId { get; set; }

        public bool Isbooking_Confirmed { get; set; }
        public int HospitalId { get; set; }
        
       
        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}
