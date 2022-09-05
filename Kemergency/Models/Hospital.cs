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
        [Display(Name = "Hospital Name")]
      
        public string Name { get; set; }
     
    
        public string  Address { get; set; }
        public string Image { get; set; }
        [Display(Name = "phone Number")]
     
        public string Telephone { get; set; }
        [Display(Name = "Open Hours")]
      
        public DateTime DateOpen { get; set; }
        [Display(Name = "Close Date")]
        public DateTime ClosDate { get; set; }

        public Status Status { get; set; }
        [Display(Name = "Status")]
      
        public int StatusId { get; set; }
        [Display(Name = "Ambulance")]
      
        public string NumberOfAmbuliance { get; set; }
      
        public int HserviceId { get; set; }
        public Hservice Hservice { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
