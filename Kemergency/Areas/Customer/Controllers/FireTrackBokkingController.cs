using Kemergency.Bussiness;
using Kemergency.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kemergency.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class FireTrackBokkingController : Controller
    {

        private readonly FireTrackBookingServices _context;
        public FireTrackBokkingController(FireTrackBookingServices context)
        {
            _context = context;
        }

        [Route("Customer/FireTrackBokking/index")]
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var viewModel = _context.GetAllByCustomerId(userId).Select(br => new FireTrackBookingViewModel
            {
                ServicesName = br.FireTrack.Name,
                DriverName = br.FireTrack.DriverName,
                DriverNumber = br.FireTrack.DriverNumber,
                confirmed = br.IsbookingConfirmed,
                FirtrackAddress = br.FireTrack.Address,
                FireTrackNumber = br.FireTrack.phoneNumber,
            });
            return View(viewModel);
        }




        [Route("Customer/FireTrackBokking/Details")]
        public IActionResult Details(string id)
        {

            if (id == null)
            {
                return ViewBag("NotFOund");
            }

            var bookingDetails = _context.GetByCustomerId(id);
            // var hospitalDetails = _hospitalservices.GetByServices(id);

            var viewModel = new FireTrackBookingViewModel
            {
                Bookingtime = bookingDetails.BookingTime,
                confirmed = bookingDetails.IsbookingConfirmed,
                ServicesName = bookingDetails.FireTrack.Name,
                DriverName = bookingDetails.FireTrack.DriverName,
                DriverNumber = bookingDetails.FireTrack.DriverNumber,
                UId = bookingDetails.MyuserId,


            };


            return PartialView("Details", viewModel);
        }
    }
}

