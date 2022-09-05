using Kemergency.Data;
using Kemergency.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Bussiness
{
    public class AmbulanceServices
    {
        private ApplicationDbContext _context;

        public AmbulanceServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public void  Add(Hservice newservice)
        {
            _context.Add(newservice);
            _context.SaveChanges();
        }

        public Hservice GetById(int id)
        {
            return _context.Hservices.Where(h => h.Id == id).FirstOrDefault();
        }

        public void Editservic(Hservice editservice)
        {
            _context.Entry(editservice).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
