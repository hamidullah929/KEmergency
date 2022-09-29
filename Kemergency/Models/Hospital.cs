using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="نوم داخل کړي ")]
        [StringLength(100)]
        [Display(Name = " هسبتال نوم")]

        public string Name { get; set; }
        [Required(ErrorMessage = "ادرس داخل کړي ")]
        [StringLength(250)]
        [Display(Name = " هسبتال ادرس")]
        public string  Address { get; set; }
        public string Image { get; set; }
        [Display(Name = " هسبتال تلیفون")]
        [Phone(ErrorMessage = "تلیفون ")]
        public string Telephone { get; set; }
        [Display(Name = " کاري وخت ")]

        public DateTime DateOpen { get; set; }
        [Display(Name = " کاري وخت ")]
        public DateTime ClosDate { get; set; }
        [Display(Name = " حالت")]
        [Required(ErrorMessage = "حالت داخل کړي ")]
        public Status Status { get; set; }
        [Required(ErrorMessage = "حالت داخل کړي ")]
        [Display(Name = " حالت")]
        public int StatusId { get; set; }
        [Display(Name = "امبولانسونو تعداد")]
        [Required(ErrorMessage = "امبولانسونو تعداد داخل کړي ")]
        public string NumberOfAmbuliance { get; set; }
        [Display(Name = " خدمات نوم")]
        [Required(ErrorMessage = "ا خدمات نوم داخل کړي ")]
        public int HserviceId { get; set; }
        [Display(Name = " خدمات نوم")]
        [Required(ErrorMessage = "ا خدمات نوم داخل کړي ")]
        public Hservice Hservice { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
