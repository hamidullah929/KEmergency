using Kemergency.Bussiness;
using Kemergency.Data;
using Kemergency.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private BookingServices _context;
        private ApplicationDbContext _dbcontex;
        private HospitalServices _hospitalservices;
        public BookingController(BookingServices context, UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext, HospitalServices hospitalservices)
        {
            _userManager = userManager;
            _context = context;
            _dbcontex = dbContext;
            _hospitalservices = hospitalservices;
        }
        public IActionResult Index()
        {
           
            var hs = _hospitalservices.GetAll();
            var bookingmode = _context.GetAll().Select(b => new HospitalBookingViewModel
            {
                CustomerName = b.Myusers.Name,
                CustomerNumber = b.Myusers.Phone,
                CustomerAddress = b.Myusers.Address,
               UId = b.MyusersId,
                Bookingtime = b.DateRented,
               // confirmed = b.Isbooking_Confirmed,



            }).ToList();
           

            return View(bookingmode);
          
        }

        public IActionResult Details(int id)
        {
               var bookingmodel = _context.GetById(id);

            var model = new HospitalBookingViewModel
            {
                Bookingtime = bookingmodel.DateRented,
                CustomerName = bookingmodel.Myusers.Name,
              
                CustomerNumber = bookingmodel.Myusers.Phone,
                CustomerAddress = bookingmodel.Myusers.Address,
            };
            return View(model);
        }
    }
}
