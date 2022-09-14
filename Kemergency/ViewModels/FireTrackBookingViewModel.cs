using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.ViewModels
{
    public class FireTrackBookingViewModel
    {
        public int Id { get; set; }
        public string UId { get; set; }
        [Display(Name = "نوم ")]
        public string CustomerName { get; set; }
        [Display(Name = "تليفون")]
        public string CustomerNumber { get; set; }
        [Display(Name = "ادرس")]
        public string CustomerAddress { get; set; }
        public string FirtrackAddress { get; set; }
        [Display(Name = "اطفايي مرکز نمبر")]
        public string FireTrackNumber { get; set; }
        [Display(Name = " موټروان ")]
        public string DriverName { get; set; }
        [Display(Name = " موټروان نمبر")]
        public string DriverNumber { get; set; }
        [Display(Name = "خدمات")]
        public string ServicesName { get; set; }
        public byte FireTrackId { get; set; }
        [Display(Name = "تاید")]
        public bool confirmed { get; set; }
        [Display(Name = "وخت")]
        public DateTime Bookingtime { get; set; }
    }
}
