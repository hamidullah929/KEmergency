using Kemergency.Bussiness;
using Kemergency.Data;
using Kemergency.Models;
using Kemergency.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Areas.Hospital_.Controllers
{
    [Area("Hospital_")]
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
        [Route("Hospital_/Booking/index")]
        public IActionResult Index()
        {

            var bookingmode = _context.GetAll().Select(b => new HospitalBookingViewModel
            {

               CustomerName = b.Myusers.Name,
                CustomerNumber = b.Myusers.Phone,
                CustomerAddress = b.Myusers.Address,
                Id = b.Id,
                Bookingtime = b.DateRented,
                confirmed = b.Isbooking_Confirmed,



            });


            return View(bookingmode);

        }
        [Route("Hospital_/Booking/Details")]
        public IActionResult Details(int id)
        {
            var bookingmodel = _context.GetBYHospitalId(id);

            var model = new HospitalBookingViewModel
            {
                Bookingtime = bookingmodel.DateRented,
                CustomerName = bookingmodel.Myusers.Name,

                CustomerNumber = bookingmodel.Myusers.Phone,
                CustomerAddress = bookingmodel.Myusers.Address,
            };
            return PartialView("Details", model);
        }

        [Route("Hospital_/Booking/EditHospitalBooking")]
        public IActionResult EditHospitalBooking(int id)
        {
            var myuser = _context.GetBYHospitalId(id);
            //if(myuser == null)
            //{
            //    return null;
            //}
            var editmodel = new EditBookingViewModel
            {
                Id = myuser.Id,
                MyusersId = myuser.MyusersId,
                HospitalId = myuser.HospitalId,
                DateRented = myuser.DateRented,
                DateReturned = myuser.DateReturned,
                Isbooking_Confirmed = myuser.Isbooking_Confirmed,
            };

            return PartialView("EditHospitalBooking", editmodel);

        }


        [Route("Hospital_/Booking/Edit")]
        [HttpPost]
        public IActionResult Edit( EditBookingViewModel model)

        {
            bool success = false;

            //if (_context.EditRentals(editmodel.Id))
            //{
            //    return RedirectToAction("index");
            //}
            //else
            //{
            //    return RedirectToAction("index");
            //}


            if (_context.EditRentals(model.Id))
            {
                success = true;
                return Json( new { success});
            }
            else
            {
                success = false;
                return Json(new { success });
               
            }

        }

        [Route("Hospital_/Booking/DeleteBooking")]
        [HttpGet]
        public IActionResult DeleteBooking(int id)
        {
            var bookingmodel = _context.GetBYHospitalId(id);

            var model = new HospitalBookingViewModel
            { 
                Id = bookingmodel.Id,
                Bookingtime = bookingmodel.DateRented,
                CustomerName = bookingmodel.Myusers.Name,

                CustomerNumber = bookingmodel.Myusers.Phone,
                CustomerAddress = bookingmodel.Myusers.Address,
            };

            return PartialView("DeleteBooking", model);
        }



        [Route("Hospital_/Booking/DeleteBooking")]
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {

            bool success = false;

            if ( _context.DeleteRentals(id))
            {
              
                return RedirectToAction("Index");
            }
            else
            {
              
                return RedirectToAction("Index");
            }

          


           
        }

    }
}
