using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Dtos
{
    public class HospitalHourDto
    {
        public int Id { get; set; }


      
        public string DayOfWeek { get; set; }

     
        public string OpenTime { get; set; }

       
        public string CloseTime { get; set; }
    }
}
