using Kemergency.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.ViewModels
{
    public class NewHospitalViewModel
    {
        [BindNever]
        [Display(Name = " حالت")]
        public IEnumerable<Status> Statuse { get; set; }
        [BindNever]
        [Display(Name = " خدمات")]
        public IEnumerable<Hservice> hservices { get; set; }
        [BindNever]
        [Display(Name = " هسپتال نوم")]
        public Hospital  Hospital { get; set; }
     
        public int Id { get; set; }
        [BindNever]
        [Display(Name = " خدمات نوم")]
        public string ServicesName { get; set; }
        [Display(Name = " هسپتال نوم")]
        public string Name { get; set; }

        [BindNever]
        [Display(Name = " هسپتال ادرس")]
        public string Address { get; set; }

        [BindNever]
        [Display(Name = " هسپتال تلیفون")]
        public string Telephone { get; set; }

        [Display(Name = " کاري وخت ")]

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOpen { get; set; }

        [BindNever]
        [Display(Name = " حالت")]
        public Status Status { get; set; }
        [BindNever]
        [Display(Name = " حالت")]
        public byte StatusId { get; set; }

        [BindNever]
        [Display(Name = " د امبولانسونو تعداد")]
        public string NumberOfAmbuliance { get; set; }

        [BindNever]
        public byte HospitalHourId { get; set; }

        [BindNever]
        public byte HserviceId { get; set; }
      
      
    }
}
