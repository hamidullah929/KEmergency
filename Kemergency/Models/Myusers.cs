using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Models
{
    public class Myusers 
    {
        public string Id { get; set; }
        [Display(Name ="نوم")]
        public string Name { get; set; }
        [Display(Name = "تليفون")]
        public string Phone { get; set; }
        public string Image { get; set; }
        [Display(Name = "ادرس")]
        public string Address { get; set; }
        [Display(Name = "دتذکیري نمبر")]
        public string NicNubmer { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
