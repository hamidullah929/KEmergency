using Kemergency.Data;
using Kemergency.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Bussiness
{
    public class CustomerServices
    {
        private ApplicationDbContext _context;
        public CustomerServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Myusers> GetAllCustomer()
        {
            return _context.Customers.ToList();
        }

        public Myusers GetById(string id)
        {
            return _context.Customers.Where(c => c.Id == id).FirstOrDefault();
        }

       public void EditUser(Myusers newuser)
        {
            try
            {
                _context.Entry(newuser).State = EntityState.Modified;
                _context.SaveChanges();
              
            }
            catch (Exception ex)
            {
               
            }
        }

    }
}
