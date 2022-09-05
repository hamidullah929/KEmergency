using Kemergency.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public Myusers Myusers { get; set; }
        public string MyusersId { get; set; }

        public string CurrentUserId { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public byte Ambulanc_SchedualId { get; set; }
        public bool Isbooking_Confirmed { get; set; }
        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}
