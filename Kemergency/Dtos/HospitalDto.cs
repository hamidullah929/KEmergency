using Kemergency.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Dtos
{
    public class HospitalDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string Telephone { get; set; }
     
        public DateTime DateOpen { get; set; }
       

        public StatusDto Status { get; set; }
       

        public byte StatusId { get; set; }
       

        public string NumberOfAmbuliance { get; set; }
        public HospitalHourDto HospitalHour { get; set; }
      

        public byte HospitalHourId { get; set; }
      
        public byte HserviceId { get; set; }
     
        public IFormFile ImageFile { get; set; }
        public HopitalServicesDto Hservice { get; set; }
     
    }
}
