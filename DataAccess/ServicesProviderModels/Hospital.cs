using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ServicesProviderModels
{
   public  class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string WhatsApp { get; set; }
        public bool IsActive { get; set; }
        public bool isDeleted { get; set; }
        public HospitalServices HospitalServices { get; set; }

    }
}
