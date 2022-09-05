using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Models
{
    public class Hservice
    {
        public int Id { get; set; }
        [Display(Name= "د خدماتونوم ")]
        public string Name { get; set; }
        public string DrvierName { get; set; }
        public string AvaliableAmbulianc { get; set; }
        public string DriverNumber { get; set; }

    }
}
