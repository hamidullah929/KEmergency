using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.ViewModels
{
    public class HospitalBookingViewModel
    {
        public int Id { get; set; }
        public string UId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerAddress { get; set; }
        public string HospitalNAme { get; set; }
        public string HsopitalNumber { get; set; }
        public string DriverName { get; set; }
        public string DriverNumber { get; set; }
        public string ServicesName { get; set; }
        public byte AmbulanceId { get; set; }
        public bool confirmed { get; set; }
        public DateTime Bookingtime { get; set; }
        

    }
}
