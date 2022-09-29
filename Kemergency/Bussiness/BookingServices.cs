using Kemergency.Data;
using Kemergency.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Bussiness
{
    public class BookingServices
    {
        private readonly ApplicationDbContext _context;

        public BookingServices(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Rental> GetAll()
        {
            var bookings = _context.Rentals.Include(c => c.Myusers).Include(h=>h.Hospital).Include(g=>g.Hospital.Hservice).ToList();

            return bookings;
        }

        

        public  Rental GetById(int id)

        {
            var booking = _context.Rentals.Include(c => c.Myusers).Include(h=>h.Hospital).Include(hs=>hs.Hospital.Hservice)
               .SingleOrDefault(d => d.Id == id);
            return booking;
        }           

        public IEnumerable<Rental> GetAllByCustomerId(string cId)
        {
            var booking = _context.Rentals.Where(c => c.MyusersId == cId).
                Include(c=>c.Hospital).Include(hs => hs.Hospital.Hservice).ToList();
            return booking;
        }

        public IEnumerable<Rental> GetAllByHospitalId(int HId)
        {
            var booking = _context.Rentals.Where(c => c.HospitalId == HId).
                Include(c => c.Hospital).Include(hs => hs.Hospital.Hservice).ToList();
            return booking;
        }


        public Rental GetByCustomer(int bookingId)
        {
            var booking = _context.Rentals.Include(c => c.Myusers).First(b => b.Id == bookingId);

            return booking;
        }

        public Rental GetByCustomreId(string id)

        {
            var booking = _context.Rentals.Include(c => c.Myusers).
                Include(c => c.Hospital).Include(hs => hs.Hospital.Hservice)
               .FirstOrDefault(d => d.MyusersId == id);
            return booking;
        }
        public Rental GetBYHospitalId(int id)

        {
            var booking = _context.Rentals.Include(c => c.Myusers).
                Include(c => c.Hospital).Include(hs => hs.Hospital.Hservice)
               .SingleOrDefault(d => d.Id == id);
            return booking;
        }
        public Rental GetByHospital(int bookingId)
        {
            var booking = _context.Rentals.First(b => b.Id == bookingId);

            return booking;
        }

        public void Create(Rental NewBooking)
        {
            NewBooking.DateRented = TimeZone.CurrentTimeZone.ToUniversalTime(DateTime.Now);
            _context.Add(NewBooking);
        }

        public bool EditRentals(int id)
        {

            var getrental = _context.Rentals.Where(c => c.Id == id).SingleOrDefault();
            getrental.Isbooking_Confirmed = true;
           
            try
            {
                
                _context.Entry(getrental).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
           


        }

        public bool DeleteRentals(int id)
        {
            var getrental = _context.Rentals.Where(c => c.Id == id).FirstOrDefault();
            try
            {
                _context.Rentals.Remove(getrental);
                _context.SaveChanges();
                return true;
            }
           catch(Exception)
            {
                return false;
            }
        }


        
    }
}
