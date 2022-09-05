using Kemergency.Data;
using Kemergency.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Bussiness
{
    public class HospitalServices
    {
        private ApplicationDbContext _context;

        public HospitalServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public Hospital GetByid(int id)
        {
            var hospital = _context.Hospitals.Include(s => s.Status).Include(s => s.Hservice).FirstOrDefault(h => h.Id == id);

            return hospital;
        }

        public Hospital GetByServices(int id)
        {
            var hospital = _context.Hospitals.FirstOrDefault(h => h.Id == id);

            return hospital;
        }

        public IEnumerable<Hospital> GetAll()
        {
            return _context.Hospitals.Include(a => a.Status).Include(a => a.Hservice);
        }

        public IEnumerable<Hservice> GetServices(int hospitalId)
        {
            return (IEnumerable<Hservice>)_context.Hospitals.Include(a => a.Hservice)
                .First(b => b.Id == hospitalId).Hservice;
        }


    }
}
