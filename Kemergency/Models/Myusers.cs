using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Models
{
    public class Myusers 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string NicNubmer { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
