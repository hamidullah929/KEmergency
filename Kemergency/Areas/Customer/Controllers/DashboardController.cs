using Kemergency.Bussiness;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kemergency.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class DashboardController : Controller
    {
        private BookingServices   _bookinservices;

        public DashboardController(BookingServices bookinservices)
        {
            _bookinservices = bookinservices;
        }
        [Route("Customer/dashboard/index")]
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Appointments = _bookinservices.GetAll().Count();
            return View();
        }
    }
}
