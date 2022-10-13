using Kemergency.Bussiness;
using Kemergency.Data;
using Kemergency.Models;
using Kemergency.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kemergency.Controllers
{
    public class NewRentalsController : Controller
    {
        private RentalServices _context;
        private BookingServices _bservices;
        private CustomerServices _Cservices;
        private UserManager<ApplicationUser> _signInManager;
        private IEmailServices _emailservices;
        public NewRentalsController(RentalServices context, UserManager<ApplicationUser> signInManager, BookingServices bservices, CustomerServices Cservices, IEmailServices emailservices)
        {
            _Cservices = Cservices;
            _bservices = bservices;
            _context = context;
            _signInManager = signInManager;
            _emailservices = emailservices;
        }

        public IActionResult New(int id)
        {
            var booking = _bservices.GetById(id);
            var Rentals = new Rental
            {
                MyusersId = booking.MyusersId,
                HospitalId = booking.HospitalId,
                Ambulanc_SchedualId = booking.Ambulanc_SchedualId,
                DateRented = DateTime.Now,
                DateReturned = DateTime.Now,

            };

            return PartialView("_New", booking);
        }

       [Route("NewRentals/CreateRentals")]
        public IActionResult CreateRentals(NewHospitalViewModel  newrental)
        {
            bool success = false;
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var rental = new Rental
            {
                MyusersId = user,
                HospitalId = newrental.Id,
                CurrentUserId =user,
                DateRented = DateTime.Now,
            };

            var message = new Message
            {
                EmailToId = "hamidullahrostai@gmail.com",
                EmailToName = "Hi",
                EmailSubject = "تا سو خدمات په بریالی توب ونیول",
                EmailBody = "تا سوچي کو خدمات نیولي هغه به ډیر ژر ورسیږي",

            };
            _emailservices.sendEmail(message);

            if(!ModelState.IsValid)
            {
                return ViewBag("Inter Valid Data");
            }
            if (_context.CreateRental(rental))
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
