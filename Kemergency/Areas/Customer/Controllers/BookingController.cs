using Kemergency.Bussiness;
using Kemergency.Data;
using Kemergency.Helpers;
using Kemergency.Models;
using Kemergency.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kemergency.Areas.Customer.Controllers
{
    [Area("Customer")]
 
    public class BookingController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private BookingServices _context;
        private ApplicationDbContext  _dbcontex;
        private HospitalServices _hospitalservices;
        private UserManager<ApplicationUser> _signInManager;
        public BookingController(UserManager<ApplicationUser> userManager, UserManager<ApplicationUser> signInmanager, BookingServices context, ApplicationDbContext dbContext, HospitalServices hospitalservices)
        {
            _userManager = userManager;
            _context = context;
            _dbcontex = dbContext;
            _hospitalservices = hospitalservices;
            _signInManager = signInmanager;
        }
        [Route("Customer/booking/index")]
        public IActionResult Index()
        {


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = _context.GetAllByCustomerId(userId).
               
                Select(br => new HospitalBookingViewModel
              {


                UId = br.MyusersId,
                Bookingtime  = br.DateRented,
                confirmed = br.Isbooking_Confirmed,
                HospitalNAme = br.Hospital.Name,
                HsopitalNumber = br.Hospital.Telephone,
                ServicesName = br.Hospital.Hservice.Name,
                DriverName = br.Hospital.Hservice.DrvierName,
                DriverNumber = br.Hospital.Hservice.DriverNumber,

            });

          
              //.Select(br => new HospitalBookingViewModel
              //{
                  

              //    Id 
              //    Bookingtime  = br.DateRented,
              //    confirmed = br.Isbooking_Confirmed,
              //    HospitalNAme = br.Hospital.Name,
              //    ServicesName = br.Hospital.Hservice.Name,
              //    DriverName = br.Hospital.Hservice.DrvierName,
              //    DriverNumber = br.Hospital.Hservice.DriverNumber,
                  
              //});

        

            return View(viewModel);
        }

        [Route("Customer/booking/Details")]
        public IActionResult Details(string id)
        {
            
            if(id == null)
            {
                return ViewBag("NotFOund");
            }

            var bookingDetails = _context.GetByCustomreId(id);
           // var hospitalDetails = _hospitalservices.GetByServices(id);
            
            var viewModel = new HospitalBookingViewModel
            {
                Bookingtime = bookingDetails.DateRented,
                confirmed = bookingDetails.Isbooking_Confirmed,
                HospitalNAme = bookingDetails.Hospital.Name,
                HsopitalNumber = bookingDetails.Hospital.Telephone,
                ServicesName = bookingDetails.Hospital.Hservice.Name,
                DriverName = bookingDetails.Hospital.Hservice.DrvierName,
                DriverNumber = bookingDetails.Hospital.Hservice.DriverNumber,
                UId = bookingDetails.MyusersId,


            };
          

            return PartialView("Details",viewModel);
        }
    }
}
