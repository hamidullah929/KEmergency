using Kemergency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.ViewModels
{
    public class RentalViewModel
    {
        public int Id { get; set; }
        public string ServicesName { get; set; }
        public string HospitalName { get; set; }
        public string Drivernumber { get; set; }
        public DateTime BookingTime { get; set; }
        public string DriverName { get; set; }
        public string HospitalNumber { get; set; }

       
    }
}
