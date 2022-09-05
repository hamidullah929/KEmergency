using Kemergency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.ViewModels
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public IEnumerable<Hservice> hservices { get; set; }
        public IEnumerable<Status> Statuse { get; set; }
       

        public IEnumerable<Rental> Rental { get; set; }
        public string ServicesName { get; set; }

        public string HospitalOpenHour { get; set; }
        public DateTime CloseTime { get; set; }
        public DateTime OpenTime { get; set; }
        public string HospitalStaus { get; set; }
        public byte ServicesId { get; set; }
        public string AvaliableAmbuliance { get; set; }
        public string Phone { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
      
        public string DriverNumber { get; set; }


    }
}
