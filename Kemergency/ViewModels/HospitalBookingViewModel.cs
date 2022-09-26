using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.ViewModels
{
    public class HospitalBookingViewModel
    {
        public int Id { get; set; }
        public string UId { get; set; }
        [Display(Name = " مشتري نوم")]
        public string CustomerName { get; set; }
        [Display(Name = " مشتري نمبر")]
        public string CustomerNumber { get; set; }
        [Display(Name = " مشتري ادرس")]
        public string CustomerAddress { get; set; }
        [Display(Name = " هسپتال نوم")]
        public string HospitalNAme { get; set; }
        [Display(Name = " هسپتال نمبر")]
        public string HsopitalNumber { get; set; }
        [Display(Name = " موټر وان")]
        public string DriverName { get; set; }
        [Display(Name = " موټر وان نمیر")]
        public string DriverNumber { get; set; }
        [Display(Name = "  خدمات")]
        public string ServicesName { get; set; }
        public byte AmbulanceId { get; set; }
        [Display(Name = "  تا ید کول")]
        public bool confirmed { get; set; }
        [Display(Name = " دنیولو وخت")]
        public DateTime Bookingtime { get; set; }
        

    }
}
