using Kemergency.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.ViewModels
{
    public class NewHospitalViewModel
    {
        [BindNever]
        public IEnumerable<Status> Statuse { get; set; }
        [BindNever]
  
        public IEnumerable<Hservice> hservices { get; set; }
        [BindNever]
        public Hospital  Hospital { get; set; }
     
        public int Id { get; set; }
        [BindNever]
        public string ServicesName { get; set; }
        public string Name { get; set; }

        [BindNever]
        public string Address { get; set; }

        [BindNever]
        public string Telephone { get; set; }
        

        public DateTime DateOpen { get; set; }

        [BindNever]
        public Status Status { get; set; }
        [BindNever]
        public byte StatusId { get; set; }

        [BindNever]
        public string NumberOfAmbuliance { get; set; }

        [BindNever]
        public byte HospitalHourId { get; set; }

        [BindNever]
        public byte HserviceId { get; set; }
      
      
    }
}
