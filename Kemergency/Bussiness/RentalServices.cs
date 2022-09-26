using Kemergency.Data;
using Kemergency.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Bussiness
{
    public class RentalServices
    {
        private ApplicationDbContext _context;

        public RentalServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Rental> GetAllRental()
        {
            var rentals = _context.Rentals.Include(c => c.Myusers).ToList();
            return rentals;
        }

        public bool CreateRental(Rental newRental)
        {
            try
            {
                _context.Add(newRental);
                _context.SaveChanges();
                return true;
            }catch(Exception e)
            {
                throw;
            }
           
        }

        public Rental GetById(int id)
        {
            var rental = _context.Rentals.Include(c => c.Myusers).FirstOrDefault(c => c.Id == id);
            return rental;
        }

        public Rental GetByAmbulanceId(int id)
        {
            return null;
        }


    }
}
