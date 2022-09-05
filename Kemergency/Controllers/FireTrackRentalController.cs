using Kemergency.Areas.FireTrackK.Models;
using Kemergency.Bussiness;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kemergency.Controllers
{
    public class FireTrackRentalController : Controller
    {
        private FireTrackRentalService _context;

        public FireTrackRentalController(FireTrackRentalService context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("FireTrackRental/CreateRentals")]
        public IActionResult CreateRentals(FireTrack newrental)
        {
            bool success = false;
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var rental = new FireTrackBooking
            {
                MyuserId = user,
                FireTrackId = newrental.Id,
                BookingTime = DateTime.Now,
            };

            if (_context.createRentals(rental))
            {
                success = true;
                return Json(new { success });
            }
                

            else
            {
                return Json(new { success });
            }
                
        }
    }
}
