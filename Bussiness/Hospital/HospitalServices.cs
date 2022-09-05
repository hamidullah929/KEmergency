using DataAccess.Data;
using DataAccess.ServicesProviderModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.HospitalServices
{
  public  class HospitalServices
    {
        private ApplicationDbContext _context;

        public HospitalServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Hospital newHospital)
        {
            _context.Add(newHospital);
            _context.SaveChanges();
        }

        public IEnumerable <Hospital> GetAllHospitalWithServices()
        {
            return _context.Hospitals.Include(s => s.HospitalServices);
        }
        
        public void AddServices(HospitalServices newServices)
        {
            _context.Add(newServices);
            _context.SaveChanges();
        }

    }
}
