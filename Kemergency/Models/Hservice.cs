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
    
        [Required(ErrorMessage = " خدمات نوم داخل کړي ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "موټروان نوم داخل کړي ")]
        [Display(Name = "موټروان نوم ")]
        public string DrvierName { get; set; }
        [Display(Name = "دامبولانسونو تعداد  ")]
        [Required(ErrorMessage = "دامبولانسونو تعداد داخل کړي ")]
        public string AvaliableAmbulianc { get; set; }
        [Display(Name = "موټروان نمبر ")]
        [Required(ErrorMessage = "موټروان نمبر داخل کړي ")]
        [Phone]
        public string DriverNumber { get; set; }

    }
}
