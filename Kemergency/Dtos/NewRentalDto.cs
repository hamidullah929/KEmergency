using Kemergency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Dtos
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> HospitalId { get; set; }
    }
}
