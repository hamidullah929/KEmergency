using Kemergency.Areas.FireTrackK.Models;
using Kemergency.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Bussiness
{
     
    public class FireTrackBookingServices
    {
        private readonly ApplicationDbContext _context;

        public FireTrackBookingServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<FireTrackBooking> getAll()
        {
            return _context.FireTrackBookings.Include(m=>m.Myuser).Include(f=>f.FireTrack).ToList();
        }

        public FireTrackBooking getbyId(int id)
        {
            return _context.FireTrackBookings.Include(m => m.Myuser).Include(f => f.FireTrack).Where(f => f.Id == id).SingleOrDefault();
        }

        public FireTrackBooking GetByTrackId(int id)
        {
          return  _context.FireTrackBookings.Include(m => m.Myuser).Include(f => f.FireTrack).Where(f => f.FireTrackId == id).SingleOrDefault();
        }

        public IEnumerable <FireTrackBooking> GetAllByCustomerId(string id)
        {
            return _context.FireTrackBookings.Where(m => m.MyuserId == id).Include(f => f.FireTrack).ToList();
        }

        public FireTrackBooking GetByCustomerId(string id)
        {
            return _context.FireTrackBookings
                .Where(m => m.MyuserId == id)
                .Include(f => f.FireTrack).SingleOrDefault();
        }

    }
}
