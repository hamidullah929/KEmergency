using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Areas.FireTrackK.Models
{
    public class FireTrack
    {
        public int Id { get; set; }
        [Display (Name="نوم")]
        public string Name { get; set; }
        [Display(Name = "ادرس")]
        public string Address { get; set; }
        [Display(Name = "موټر نمبر")]
        public string TrackNumber { get; set; }
        [Display(Name = "مرکزي نمبر")]
        public string phoneNumber { get; set; }
        [Display(Name = "موټر وان نوم")]
        public string DriverName { get; set; }
        [Display(Name = "موټر وان نمبر")]
        public string DriverNumber { get; set; }

    }
}
