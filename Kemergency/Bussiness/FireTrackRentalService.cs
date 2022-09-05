using Kemergency.Areas.FireTrackK.Models;
using Kemergency.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Bussiness
{
    public class FireTrackRentalService
    {
        private ApplicationDbContext _context;
        public FireTrackRentalService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool createRentals(FireTrackBooking  fireTrack)
        {
            try
            {
                _context.Add(fireTrack);
                _context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                throw;
            }
           
        }
    }
}
