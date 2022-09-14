using Kemergency.Bussiness;
using Kemergency.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemergency.Areas.FireTrackK.Controllers
{
    [Area("FireTrackK")]
    public class BookingController : Controller
    {
        private readonly FireTrackBookingServices _context;

        public BookingController(FireTrackBookingServices context)
        {
            _context = context;
        }
        [Route("FireTrackK/Booking/index")]
        public IActionResult Index()
        {
            var bookingmode = _context.getAll().Select(b => new FireTrackBookingViewModel
            {

                CustomerName = b.Myuser.Name,
                CustomerNumber = b.Myuser.Phone,
                CustomerAddress = b.Myuser.Address,
                Id = b.Id,
                Bookingtime = b.BookingTime,
                confirmed = b.IsbookingConfirmed,



            });


            return View(bookingmode);
        
        }

        [Route("FireTrackK/Booking/Details")]
        public IActionResult Details(int id)
        {
            var bookingmodel = _context.GetByTrackId(id);

            var model = new FireTrackBookingViewModel
            {
                Bookingtime = bookingmodel.BookingTime,
                CustomerName = bookingmodel.Myuser.Name,

                CustomerNumber = bookingmodel.Myuser.Phone,
                CustomerAddress = bookingmodel.Myuser.Address,
            };
            return PartialView("Details", model);
        }
    }
}
